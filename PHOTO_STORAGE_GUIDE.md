# Joshua Events - Photo Storage & Deployment Guide

## 📸 Photo Storage System

### Current Implementation
Your photos are stored using **Base64 encoding in browser localStorage**.

### How It Works:
1. **Upload Photo**: Select an image file (Max 5MB)
2. **Conversion**: Image is converted to Base64 data URL
3. **Storage**: Photo data saved in browser's localStorage
4. **Display**: Base64 images display directly in gallery

### Storage Location:
- **Browser**: `localhost` → localStorage key: `joshuaevents_photos`
- **Data Format**: JSON array with photo metadata + Base64 images

---

## 🚀 Deployment Options

### Option 1: GitHub Pages (Free & Easy) ✅ **RECOMMENDED**

#### Setup Steps:
1. Create GitHub repository
2. Push your code to GitHub
3. Enable GitHub Pages in repository settings
4. Your site will be live at: `https://yourusername.github.io/JoshuaEvents`

#### Pros:
- ✅ Free hosting
- ✅ Works with Blazor WebAssembly
- ✅ SSL certificate included
- ✅ Custom domain supported

#### Cons:
- ❌ localStorage data is browser-specific
- ❌ Photos don't sync across devices

---

### Option 2: Azure Static Web Apps (Professional)

#### Setup:
```bash
# Install Azure CLI
# Deploy
az staticwebapp create --name joshua-events --resource-group myResourceGroup
```

#### Pros:
- ✅ Professional hosting
- ✅ Custom domains
- ✅ SSL included
- ✅ Can add backend API

---

### Option 3: Netlify (Popular Choice)

1. Connect your GitHub repo
2. Build command: `dotnet publish -c Release`
3. Publish directory: `bin/Release/net10.0/publish/wwwroot`
4. Deploy automatically on git push

---

## 📤 Export/Import Data for Deployment

### Before Deployment:
1. Go to **Add Photos** page
2. Click **"Export Data"** button
3. Save the JSON file
4. After deployment, use **"Import Data"** to restore photos

---

## 🔄 Upgrade to Cloud Storage (For Production)

### Recommended: Cloudinary (Free Tier - 25GB storage)

#### Setup:
1. Create account at [cloudinary.com](https://cloudinary.com)
2. Get API credentials
3. Update `PhotoService.cs` to use Cloudinary API
4. Images hosted on CDN (faster loading)

#### Benefits:
- ✅ Unlimited devices can access photos
- ✅ Fast CDN delivery
- ✅ Image transformations (resize, compress)
- ✅ No browser storage limits

---

## 📊 Storage Limits

### Current (localStorage):
- **Limit**: 5-10MB per domain
- **Recommendation**: Max 20-30 photos
- **Best for**: Testing & development

### After Cloud Storage:
- **Cloudinary Free**: 25GB storage
- **Unlimited photos**: No practical limit

---

## 🛠️ Quick Deployment Checklist

- [ ] Export your photos data (JSON file)
- [ ] Test locally: `dotnet run`
- [ ] Build for production: `dotnet publish -c Release`
- [ ] Choose hosting platform (GitHub Pages recommended)
- [ ] Deploy files from `bin/Release/net10.0/publish/wwwroot`
- [ ] Import photos data after deployment
- [ ] Test all features on live site

---

## 📞 Support
For help with deployment, contact: info@joshuaevents.com

---

## 🔮 Future Enhancements
- [ ] Cloudinary integration
- [  ] Admin authentication
- [ ] Image optimization
- [ ] Bulk upload
- [ ] Photo categories/tags
