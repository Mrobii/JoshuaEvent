# 🚀 Joshua Events - Deployment Guide

## 📖 Project Overview

**Joshua Events** is a modern Blazor WebAssembly event decoration services website with database-free photo management using localStorage, ready to deploy to any static hosting platform like GitHub Pages.

**Your Repository**: https://github.com/Mrobii/JoshuaEvent-s  
**Your Live URL** (after deployment): https://mrobii.github.io/JoshuaEvent-s/

---

## Quick Deploy to GitHub Pages (5 Minutes)

### Step 1: Create GitHub Repository
```bash
# Your repository already exists at:
# https://github.com/Mrobii/JoshuaEvent-s

# Push your latest changes
git add .
git commit -m "Add deployment configuration and photo management features"
git push origin master
```

### Step 2: Build for Production
```bash
dotnet publish -c Release -o publish
```

### Step 3: Deploy to GitHub Pages

#### Option A: Using GitHub Actions (Automatic)

Create `.github/workflows/deploy.yml`:

```yaml
name: Deploy to GitHub Pages

on:
  push:
	branches: [ main ]

jobs:
  deploy:
	runs-on: ubuntu-latest
	steps:
	  - uses: actions/checkout@v3

	  - name: Setup .NET
		uses: actions/setup-dotnet@v3
		with:
		  dotnet-version: '10.0.x'

	  - name: Publish
		run: dotnet publish JoshuaEvents/JoshuaEvents.csproj -c Release -o publish

	  - name: Deploy to GitHub Pages
		uses: peaceiris/actions-gh-pages@v3
		with:
		  github_token: ${{ secrets.GITHUB_TOKEN }}
		  publish_dir: ./publish/wwwroot
		  force_orphan: true
```

#### Option B: Manual Deploy

1. Go to repository settings
2. Navigate to **Pages**
3. Select branch: `gh-pages`
4. Save

Your site will be live at:
```
https://mrobii.github.io/JoshuaEvent-s/
```

---

## 🌐 Configure Base Path (Important!)

For GitHub Pages subdirectory hosting, update `wwwroot/index.html`:

```html
<base href="/JoshuaEvents/" />
```

---

## 🎯 Custom Domain Setup

### Step 1: Add CNAME file
Create `wwwroot/CNAME`:
```
events.joshuaevents.com
```

### Step 2: Configure DNS
Add these records to your domain:

```
Type    Name    Value
A       @       185.199.108.153
A       @       185.199.109.153
A       @       185.199.110.153
A       @       185.199.111.153
CNAME   www     YOUR_USERNAME.github.io
```

### Step 3: Enable HTTPS
In GitHub repository settings → Pages → Enable "Enforce HTTPS"

---

## 📤 Pre-Deploy Checklist

- [ ] **Export Photos**: Go to Add Photos → Export Data
- [ ] **Test Build**: `dotnet publish -c Release`
- [ ] **Check Images**: Ensure logo loads correctly
- [ ] **Test Contact Form**: Verify localStorage works
- [ ] **Mobile Test**: Check responsive design

---

## 🔧 Post-Deploy Setup

### 1. Import Photos
- Open your live site
- Navigate to `/addphotos`
- Click "Import Data"
- Upload your exported JSON file

### 2. Test All Features
- ✅ Navigation works
- ✅ Contact form saves
- ✅ Photo upload works
- ✅ Gallery displays correctly
- ✅ Mobile responsive

---

## 🐛 Troubleshooting

### Issue: Blank page after deploy
**Solution**: Check `<base href>` in index.html matches your deployment path

### Issue: Images not loading
**Solution**: Ensure images are in `wwwroot/images/` folder

### Issue: Photos don't save
**Solution**: localStorage requires HTTPS. GitHub Pages provides this automatically.

---

## 🚀 Alternative Hosting Options

### Netlify (Easiest)
1. Connect GitHub repository
2. Build: `dotnet publish -c Release`
3. Publish: `bin/Release/net10.0/publish/wwwroot`
4. Deploy on every push ✅

### Azure Static Web Apps
```bash
# Install Azure CLI
az staticwebapp create \
  --name joshua-events \
  --resource-group myResourceGroup \
  --source "https://github.com/YOUR_USERNAME/JoshuaEvents" \
  --location "Central US" \
  --branch main \
  --app-location "/" \
  --output-location "bin/Release/net10.0/publish/wwwroot"
```

### Vercel
```bash
npm i -g vercel
vercel --prod
```

---

## 📊 Performance Optimization

### Before Deploy:
```bash
# Optimize images
# Minify CSS/JS (done automatically by Blazor)
# Enable compression
```

### After Deploy:
- Enable Cloudflare CDN (free tier)
- Monitor with Google Analytics
- Test with Lighthouse

---

## 🔐 Security Considerations

### Current Setup:
✅ Static site - no server vulnerabilities  
✅ HTTPS enforced  
✅ No database - no SQL injection risk  
⚠️ Add Photos page is public (consider adding authentication later)

### Future: Add Authentication
- Azure AD B2C
- Auth0
- Firebase Auth

---

## 📈 Next Steps After Deployment

1. **Share URL**: `https://yourusername.github.io/JoshuaEvents`
2. **Test on Mobile**: Check iOS and Android
3. **Add to Google**: Submit sitemap.xml
4. **Monitor**: Set up Google Analytics
5. **Backup**: Keep photo JSON exports safe

---

## 💡 Production Tips

### Regular Backups
```bash
# Auto-backup script
# Export photos weekly via Add Photos page
# Store JSON files in cloud storage
```

### Monitor Storage
- Check localStorage usage in browser DevTools
- Export/import data if switching devices
- Consider cloud storage when photo count > 50

---

## 📞 Need Help?

**Phone**: 9036215569  
**Email**: info@joshuaevents.com  
**Office**: Near Zion Methodist Church, Zion Colony, Kumbarwada Road, Bidar - 585403 (K.S)

---

## ✅ Deployment Complete!

Your Joshua Events website is now live and accessible via URL! 🎉

**Pro Tip**: Bookmark your Add Photos admin page for quick access:
```
https://yourusername.github.io/JoshuaEvents/addphotos
```
