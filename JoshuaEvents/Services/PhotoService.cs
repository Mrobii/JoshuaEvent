using System.Text.Json;
using JoshuaEvents.Models;
using Microsoft.JSInterop;

namespace JoshuaEvents.Services;

public class PhotoService
{
    private readonly IJSRuntime _jsRuntime;
    private const string StorageKey = "joshuaevents_photos";

    public PhotoService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<List<Photo>> GetAllPhotosAsync()
    {
        try
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
            return string.IsNullOrEmpty(json)
                ? new List<Photo>()
                : JsonSerializer.Deserialize<List<Photo>>(json) ?? new List<Photo>();
        }
        catch
        {
            return new List<Photo>();
        }
    }

    public async Task<List<Photo>> GetPhotosByEventTypeAsync(string eventType)
    {
        var allPhotos = await GetAllPhotosAsync();
        return allPhotos.Where(p => p.EventType == eventType && p.IsActive).ToList();
    }

    public async Task SavePhotoAsync(Photo photo)
    {
        var photos = await GetAllPhotosAsync();
        photos.Add(photo);
        var json = JsonSerializer.Serialize(photos);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
    }

    public async Task UpdatePhotoAsync(Photo photo)
    {
        var photos = await GetAllPhotosAsync();
        var existingPhoto = photos.FirstOrDefault(p => p.Id == photo.Id);
        if (existingPhoto != null)
        {
            photos.Remove(existingPhoto);
            photos.Add(photo);
            var json = JsonSerializer.Serialize(photos);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
        }
    }

    public async Task DeletePhotoAsync(string photoId)
    {
        var photos = await GetAllPhotosAsync();
        var photo = photos.FirstOrDefault(p => p.Id == photoId);
        if (photo != null)
        {
            photos.Remove(photo);
            var json = JsonSerializer.Serialize(photos);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
        }
    }

    // Convert uploaded file to base64 data URL for storage
    public async Task<string> ConvertFileToBase64Async(string inputId)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<string>("convertFileToBase64", inputId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error converting file: {ex.Message}");
            return string.Empty;
        }
    }

    // Validate file size (limit to 5MB for localStorage)
    public bool ValidateFileSize(long fileSize)
    {
        const long maxSize = 5 * 1024 * 1024; // 5MB
        return fileSize <= maxSize;
    }
}
