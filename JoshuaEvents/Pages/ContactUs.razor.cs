using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using JoshuaEvents.Models;
using JoshuaEvents.Services;

namespace JoshuaEvents.Pages;

public partial class ContactUs : ComponentBase
{
    [Inject] private ContactService ContactService { get; set; } = default!;
    [Inject] private HttpClient Http { get; set; } = default!;

    private ContactQuery contactQuery = new();
    private bool isSubmitting = false;
    private bool showSuccessMessage = false;
    private string errorMessage = string.Empty;
    private IBrowserFile? selectedFile;
    private string? imagePreviewUrl;
    private const long maxFileSize = 5 * 1024 * 1024; // 5MB

    private async Task HandleFileSelected(InputFileChangeEventArgs e)
    {
        selectedFile = e.File;
        errorMessage = string.Empty;

        if (selectedFile != null)
        {
            // Validate file type
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(selectedFile.Name).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                errorMessage = "Please select a valid image file (jpg, jpeg, png, or gif).";
                selectedFile = null;
                imagePreviewUrl = null;
                return;
            }

            // Validate file size
            if (selectedFile.Size > maxFileSize)
            {
                errorMessage = $"File size must not exceed {maxFileSize / 1024 / 1024}MB.";
                selectedFile = null;
                imagePreviewUrl = null;
                return;
            }

            // Create preview
            try
            {
                var buffer = new byte[selectedFile.Size];
                await selectedFile.OpenReadStream(maxFileSize).ReadAsync(buffer);
                var base64 = Convert.ToBase64String(buffer);
                imagePreviewUrl = $"data:{selectedFile.ContentType};base64,{base64}";
            }
            catch (Exception ex)
            {
                errorMessage = $"Error loading image preview: {ex.Message}";
                selectedFile = null;
                imagePreviewUrl = null;
            }
        }
    }

    private void ClearImage()
    {
        selectedFile = null;
        imagePreviewUrl = null;
    }

    private async Task HandleSubmit()
    {
        isSubmitting = true;
        errorMessage = string.Empty;
        showSuccessMessage = false;

        try
        {
            if (string.IsNullOrWhiteSpace(contactQuery.Name) ||
                string.IsNullOrWhiteSpace(contactQuery.Email) ||
                string.IsNullOrWhiteSpace(contactQuery.Phone) ||
                string.IsNullOrWhiteSpace(contactQuery.EventType))
            {
                errorMessage = "Please fill in all required fields.";
                isSubmitting = false;
                return;
            }

            contactQuery.SubmittedAt = DateTime.UtcNow;

            // If there's an image, convert it to base64 and store
            if (selectedFile != null)
            {
                try
                {
                    var buffer = new byte[selectedFile.Size];
                    await selectedFile.OpenReadStream(maxFileSize).ReadAsync(buffer);
                    var base64 = Convert.ToBase64String(buffer);
                    contactQuery.AttachmentBase64 = $"data:{selectedFile.ContentType};base64,{base64}";
                    contactQuery.AttachmentFileName = selectedFile.Name;
                }
                catch (Exception ex)
                {
                    errorMessage = $"Error uploading image: {ex.Message}";
                    isSubmitting = false;
                    return;
                }
            }

            // Save to local storage
            await ContactService.SaveQueryAsync(contactQuery);

            // Send email notification
            await SendEmailNotification();

            showSuccessMessage = true;
            contactQuery = new ContactQuery();

            // Clear image after successful submission
            ClearImage();
        }
        catch (Exception ex)
        {
            errorMessage = "An error occurred while submitting your inquiry. Please try again.";
        }
        finally
        {
            isSubmitting = false;
        }
    }

    private async Task SendEmailNotification()
    {
        try
        {
            // Using Web3Forms - Free, no setup required
            var formData = new Dictionary<string, string>
            {
                { "access_key", "081e2980-fb6d-4abd-a432-2fe4e391e883" }, // Your Web3Forms access key
                { "subject", $"New Enquiry from {contactQuery.Name} - Joshua Events" },
                { "from_name", contactQuery.Name },
                { "email", "imobi4u@gmail.com" }, // Your email where you'll receive notifications
                { "Customer_Name", contactQuery.Name },
                { "Customer_Email", contactQuery.Email },
                { "Customer_Phone", contactQuery.Phone },
                { "Event_Type", contactQuery.EventType },
                { "Event_Date", contactQuery.EventDate?.ToString("dd MMM yyyy") ?? "Not specified" },
                { "Guest_Count", contactQuery.GuestCount > 0 ? contactQuery.GuestCount.ToString() : "Not specified" },
                { "Budget", contactQuery.Budget > 0 ? $"₹{contactQuery.Budget:N0}" : "Not specified" },
                { "Message", contactQuery.Message ?? "No additional message" }
            };

            // Add attachment info if present
            if (!string.IsNullOrEmpty(contactQuery.AttachmentFileName))
            {
                formData.Add("Attachment", $"File attached: {contactQuery.AttachmentFileName}");
            }

            var content = new FormUrlEncodedContent(formData);
            var response = await Http.PostAsync("https://api.web3forms.com/submit", content);

            // Log success/failure (optional)
            if (response.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("Email sent successfully!");
            }
        }
        catch
        {
            // Email sending failed but form is still saved locally
            // Don't show error to user as the main function (saving query) succeeded
        }
    }
}
