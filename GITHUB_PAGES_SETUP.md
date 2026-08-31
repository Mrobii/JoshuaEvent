# GitHub Pages Deployment - Quick Start Guide

## ✅ Your Deployment is Now Ready!

I've set up automatic GitHub Pages deployment for your Blazor WebAssembly application.

## 🚀 Deploy Now (3 Easy Steps)

### Step 1: Enable GitHub Pages
1. Go to: https://github.com/Mrobii/JoshuaEvent-s/settings/pages
2. Under **"Build and deployment"**:
   - **Source**: Select **"GitHub Actions"** (not "Deploy from a branch")
3. Click **Save** (if there's a save button)

### Step 2: Push Your Code
Open PowerShell in your project folder and run:
```powershell
git add .
git commit -m "Setup GitHub Pages deployment"
git push origin master
```

### Step 3: Wait & Visit Your Site
1. Go to: https://github.com/Mrobii/JoshuaEvent-s/actions
2. Watch the "Deploy to GitHub Pages" workflow run (takes 2-5 minutes)
3. Once complete, visit your live site:

**🌐 Your Site URL: https://mrobii.github.io/JoshuaEvent-s/**

---

## 📋 What Was Set Up

✅ GitHub Actions workflow (`.github/workflows/deploy-to-github-pages.yml`)
✅ Automatic build and deployment on every push to master
✅ Correct base path configuration for your repository name
✅ .nojekyll file to prevent Jekyll processing

---

## 🔄 Future Updates

Every time you push to master, your site will automatically redeploy:
```powershell
git add .
git commit -m "Your update message"
git push origin master
```

---

## 🐛 Troubleshooting

**Problem: Workflow fails**
- Check: https://github.com/Mrobii/JoshuaEvent-s/actions for error details
- Ensure GitHub Pages is set to "GitHub Actions" source

**Problem: Site shows 404**
- Verify GitHub Pages is enabled in repository settings
- Wait 5-10 minutes after first deployment
- Check the Actions tab to ensure workflow completed successfully

**Problem: CSS/Images not loading**
- This is handled automatically by the workflow
- The base href is updated to `/JoshuaEvent-s/` during deployment

**Manual Deployment Trigger**
If you need to redeploy without code changes:
1. Go to: https://github.com/Mrobii/JoshuaEvent-s/actions
2. Click "Deploy to GitHub Pages" workflow
3. Click "Run workflow"

---

## ℹ️ Technical Details

Your Blazor WASM app will be:
- Built with `dotnet publish` in Release mode
- Base href automatically changed from `/` to `/JoshuaEvent-s/`
- Deployed to GitHub Pages using the official deploy-pages action
- Accessible via the standard GitHub Pages URL

No server required - it's a fully static site running in the browser!
