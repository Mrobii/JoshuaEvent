# 🎉 Joshua Events - Event Decoration Services

![Joshua Events](JoshuaEvents/wwwroot/images/joshua-logo.svg)

**Professional Event Decoration & Planning Services**

> *CREATE • PLAN • CELEBRATE*

---

## 📋 About

Joshua Events specializes in decoration services for:
- 💒 **Weddings & Marriages**
- 💍 **Engagement Ceremonies**
- 🎨 **Haldi Ceremonies**
- 👶 **Cradle & Naming Ceremonies**
- 🎂 **Birthday Parties**
- 🏢 **Corporate Events**
- 🎊 **Social Gatherings**
- 💐 **Anniversary Celebrations**
- 🎭 **Mehendi Functions**

---

## 🚀 Technology Stack

- **Framework**: Blazor WebAssembly (.NET 10)
- **UI**: Bootstrap 5 + Custom CSS
- **Storage**: Browser localStorage (no database required)
- **Hosting**: Static hosting compatible (GitHub Pages, Netlify, Azure)

---

## ✨ Features

### 🏠 Home Page
- Hero section with brand logo
- Service overview cards
- Direct contact CTA

### 🎯 Our Services
- Detailed service listings
- Event categories with pricing
- Feature highlights per event type

### 📸 Photo Gallery
- Event photos organized by type
- Upload via file or URL
- Filter by event category

### 📤 Add Photos (Admin)
- Two upload methods: **File Upload** or **Image URL**
- Event type categorization
- Preview before upload
- Recent uploads management
- Export/Import data (JSON)
- LocalStorage usage tracking

### 📞 Contact Us
- Inquiry form with event type selection
- Direct phone/email links
- Office address with directions

---

## 🛠️ Getting Started

### Prerequisites
```bash
.NET 10 SDK
Visual Studio 2026 or VS Code
```

### Run Locally
```bash
cd JoshuaEvents
dotnet run
```

Open browser: `https://localhost:5001`

### Build for Production
```bash
dotnet publish -c Release -o publish
```

---

## 📸 Photo Storage System

### Current Setup: **LocalStorage**
- ✅ No database required
- ✅ Perfect for deployment
- ✅ Works on any static host
- ✅ Export/Import functionality
- ⚠️ Browser-specific (5-10MB limit)

### How Photos Are Stored:
1. **Upload**: Select image (Max 5MB)
2. **Convert**: Image → Base64 Data URL
3. **Save**: Stored in browser localStorage
4. **Display**: Base64 images render directly

### Export/Import:
- **Export**: Download photos as JSON file
- **Import**: Restore photos from JSON backup
- **Use Case**: Transfer data between browsers/devices

---

## 🌐 Deployment

### Recommended: **GitHub Pages** (Free)

```bash
# Build
dotnet publish -c Release

# Deploy to GitHub Pages
# See DEPLOYMENT.md for detailed steps
```

**Live URL**: `https://yourusername.github.io/JoshuaEvents`

### Other Options:
- Netlify
- Azure Static Web Apps
- Vercel

📖 **Full deployment guide**: See [DEPLOYMENT.md](DEPLOYMENT.md)

---

## 📂 Project Structure

```
JoshuaEvents/
├── Layout/
│   ├── MainLayout.razor          # App shell with nav & footer
│   └── NavMenu.razor              # Navigation component
├── Pages/
│   ├── Home.razor                 # Landing page
│   ├── Events.razor               # Services listing
│   ├── Gallery.razor              # Photo gallery
│   ├── AddPhotos.razor            # Photo upload (admin)
│   └── ContactUs.razor            # Contact form
├── Services/
│   ├── ContactService.cs          # Contact queries & events
│   └── PhotoService.cs            # Photo CRUD + Base64 conversion
├── Models/
│   ├── Event.cs                   # Service model
│   ├── Photo.cs                   # Photo metadata
│   └── ContactQuery.cs            # Contact inquiry
└── wwwroot/
	├── css/app.css                # Custom styles (modern design)
	├── images/joshua-logo.svg     # Brand logo
	└── index.html                 # App host + JS helpers
```

---

## 🎨 Design Features

- **Modern UI**: Gradients, glassmorphism, smooth animations
- **Typography**: Playfair Display + Poppins
- **Color Scheme**: Purple & Amber gradient theme
- **Responsive**: Mobile-first Bootstrap 5 layout
- **Accessibility**: Semantic HTML, ARIA labels

---

## 📱 Contact Information

**Phone**: [9036215569](tel:9036215569)  
**Email**: [info@joshuaevents.com](mailto:info@joshuaevents.com)  
**Address**:  
Near Zion Methodist Church  
Zion Colony, Kumbarwada Road  
Bidar - 585403 (K.S)

---

## 🔮 Future Enhancements

- [ ] Cloud storage integration (Cloudinary)
- [ ] Admin authentication
- [ ] WhatsApp inquiry integration
- [ ] Video gallery support
- [ ] Booking calendar
- [ ] Payment integration
- [ ] Customer testimonials
- [ ] Blog section

---

## 📄 Documentation

- **Deployment Guide**: [DEPLOYMENT.md](DEPLOYMENT.md)
- **Photo Storage**: [PHOTO_STORAGE_GUIDE.md](PHOTO_STORAGE_GUIDE.md)

---

## 🤝 Contributing

This is a private business website. For feature requests or issues, please contact the owner.

---

## 📜 License

© 2025 Joshua Events. All rights reserved.

---

## ⭐ Quick Start Checklist

- [x] Clone repository
- [x] Run `dotnet restore`
- [x] Run `dotnet run`
- [ ] Add your event photos via `/addphotos`
- [ ] Export photo data for backup
- [ ] Deploy to hosting platform
- [ ] Import photos to live site
- [ ] Share your URL! 🎉

---

**Built with ❤️ using Blazor WebAssembly**
