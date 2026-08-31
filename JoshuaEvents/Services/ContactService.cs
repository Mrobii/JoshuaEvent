using System.Text.Json;
using JoshuaEvents.Models;
using Microsoft.JSInterop;

namespace JoshuaEvents.Services;

public class ContactService
{
    private readonly IJSRuntime _jsRuntime;
    private const string StorageKey = "joshuaevents_contacts";

    public ContactService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<List<ContactQuery>> GetAllQueriesAsync()
    {
        try
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
            return string.IsNullOrEmpty(json) 
                ? new List<ContactQuery>() 
                : JsonSerializer.Deserialize<List<ContactQuery>>(json) ?? new List<ContactQuery>();
        }
        catch
        {
            return new List<ContactQuery>();
        }
    }

    public async Task SaveQueryAsync(ContactQuery query)
    {
        var queries = await GetAllQueriesAsync();
        queries.Add(query);
        var json = JsonSerializer.Serialize(queries);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
    }

    public List<Event> GetEvents()
    {
        return new List<Event>
        {
            new Event
            {
                Id = 1,
                Title = "Marriage Decoration",
                Description = "Transform your special day into a magical celebration with our exquisite marriage decoration services. From elegant mandap designs to stunning floral arrangements.",
                ImageUrl = "https://images.unsplash.com/photo-1519741497674-611481863552?w=800",
                Category = "Wedding",
                Features = new List<string> 
                { 
                    "Mandap Decoration", 
                    "Stage Setup", 
                    "Floral Arrangements", 
                    "Lighting Design",
                    "Entrance Decoration"
                },
                StartingPrice = 50000
            },
            new Event
            {
                Id = 2,
                Title = "Haldi Ceremony",
                Description = "Make your haldi ceremony vibrant and memorable with our traditional yet modern decoration setups featuring marigold flowers and colorful drapes.",
                ImageUrl = "https://images.unsplash.com/photo-1583939003579-730e3918a45a?w=800",
                Category = "Pre-Wedding",
                Features = new List<string> 
                { 
                    "Marigold Decoration", 
                    "Traditional Seating", 
                    "Photo Booth Setup", 
                    "Colorful Drapes"
                },
                StartingPrice = 15000
            },
            new Event
            {
                Id = 3,
                Title = "Cradle Ceremony",
                Description = "Celebrate your little one's naming ceremony with our adorable cradle decoration featuring soft pastels, balloons, and thematic elements.",
                ImageUrl = "https://images.unsplash.com/photo-1515488042361-ee00e0ddd4e4?w=800",
                Category = "Baby",
                Features = new List<string> 
                { 
                    "Cradle Decoration", 
                    "Balloon Arrangements", 
                    "Backdrop Design", 
                    "Theme-based Setup"
                },
                StartingPrice = 12000
            },
            new Event
            {
                Id = 4,
                Title = "Birthday Party",
                Description = "Create unforgettable birthday memories with our customized decoration packages for all ages - from kids' themed parties to elegant adult celebrations.",
                ImageUrl = "https://images.unsplash.com/photo-1530103862676-de8c9debad1d?w=800",
                Category = "Birthday",
                Features = new List<string> 
                { 
                    "Theme Decoration", 
                    "Balloon Arches", 
                    "Cake Table Setup", 
                    "Photo Corner",
                    "Return Gifts Packaging"
                },
                StartingPrice = 8000
            },
            new Event
            {
                Id = 5,
                Title = "Corporate Events",
                Description = "Make your corporate events stand out with professional decoration setups perfect for conferences, product launches, and company celebrations.",
                ImageUrl = "https://images.unsplash.com/photo-1511578314322-379afb476865?w=800",
                Category = "Corporate",
                Features = new List<string> 
                { 
                    "Stage Setup", 
                    "Branding Elements", 
                    "Professional Lighting", 
                    "Audio Visual Setup"
                },
                StartingPrice = 25000
            },
            new Event
            {
                Id = 6,
                Title = "Naming Ceremony",
                Description = "Welcome your little one with a beautiful naming ceremony decoration featuring elegant setups, floral backdrops, and traditional elements.",
                ImageUrl = "https://images.unsplash.com/photo-1519741497674-611481863552?w=800",
                Category = "Baby",
                Features = new List<string> 
                { 
                    "Traditional Setup", 
                    "Floral Backdrop", 
                    "Seating Arrangements", 
                    "Photo Corner",
                    "Decorative Lighting"
                },
                StartingPrice = 12000
            },
            new Event
            {
                Id = 7,
                Title = "Engagement Ceremony",
                Description = "Make your engagement unforgettable with our stunning decoration featuring elegant stage designs, floral arrangements, and ambient lighting.",
                ImageUrl = "https://images.unsplash.com/photo-1465495976277-4387d4b0b4c6?w=800",
                Category = "Pre-Wedding",
                Features = new List<string> 
                { 
                    "Stage Decoration", 
                    "Ring Ceremony Setup", 
                    "Floral Arrangements", 
                    "Photo Booth",
                    "Decorative Lighting"
                },
                StartingPrice = 20000
            },
            new Event
            {
                Id = 8,
                Title = "Social Gatherings",
                Description = "Perfect decorations for all your social events - family reunions, festivals, get-togethers, and community celebrations.",
                ImageUrl = "https://images.unsplash.com/photo-1478146896981-b80fe463b330?w=800",
                Category = "Social",
                Features = new List<string> 
                { 
                    "Custom Theme Setup", 
                    "Seating Arrangements", 
                    "Decorative Elements", 
                    "Lighting Design",
                    "Entertainment Area"
                },
                StartingPrice = 15000
            }
        };
    }
}
