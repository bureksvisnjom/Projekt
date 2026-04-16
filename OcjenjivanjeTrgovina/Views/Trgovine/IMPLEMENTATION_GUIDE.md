# CSS Implementation Guide for OcjenjivanjeTrgovina

## Quick Start

This guide explains how to integrate the newly created CSS files into your ASP.NET Core MVC application.

## Step 1: Update _Layout.cshtml

Open your `Views/Shared/_Layout.cshtml` and add the CSS file references in the `<head>` section.

### Add after Bootstrap CSS:

```html
<head>
    <!-- ... existing meta tags ... -->
    
    <!-- Bootstrap 5 CSS (if not already present) -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Bootstrap Icons (if not already present) -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.0/font/bootstrap-icons.css">
    
    <!-- OcjenjivanjeTrgovina Custom CSS Files -->
    <link rel="stylesheet" href="~/Views/Trgovine/common.css">
    <link rel="stylesheet" href="~/Views/Trgovine/Trgovine.css">
    
    <!-- View-specific CSS will be added per view (see below) -->
    @await RenderSectionAsync("ViewStyles", required: false)
    
    <!-- ... rest of head ... -->
</head>
```

### Add Bootstrap JS before closing </body>:

```html
<body>
    <!-- ... body content ... -->
    
    <!-- Bootstrap 5 JavaScript (if not already present) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    
    <!-- ... rest of scripts ... -->
</body>
```

## Step 2: Update Individual View Files

### For Index.cshtml:

Add this section at the end of the file (before closing @section or after main content):

```html
@section ViewStyles {
    <link rel="stylesheet" href="~/Views/Trgovine/Index.css">
}
```

### For Details.cshtml:

```html
@section ViewStyles {
    <link rel="stylesheet" href="~/Views/Trgovine/Details.css">
}
```

### For Create.cshtml:

```html
@section ViewStyles {
    <link rel="stylesheet" href="~/Views/Trgovine/Create.css">
}
```

## Step 3: Remove Inline Styles

After linking external CSS files, **remove the `<style>` blocks** from each CSHTML file:

### Index.cshtml
- **Remove lines:** 182-257 (the `<style>` block)
- Keep the JavaScript filtering code (lines 260-284)

### Details.cshtml
- **Remove lines:** 250-282 (the `<style>` block)

### Create.cshtml
- **Remove lines:** 141-188 (the `<style>` block)

## Step 4: Project Structure

After implementing, your project structure should look like:

```
OcjenjivanjeTrgovina/
├── Views/
│   ├── Shared/
│   │   └── _Layout.cshtml          (Updated with CSS links)
│   └── Trgovine/
│       ├── Index.cshtml            (Remove inline styles)
│       ├── Index.css               (NEW - Link in view)
│       ├── Details.cshtml          (Remove inline styles)
│       ├── Details.css             (NEW - Link in view)
│       ├── Create.cshtml           (Remove inline styles)
│       ├── Create.css              (NEW - Link in view)
│       ├── Trgovine.css            (NEW - Link in _Layout)
│       ├── common.css              (NEW - Link in _Layout)
│       └── CSS_README.md           (Documentation)
├── wwwroot/
│   ├── css/                        (Optional - for production)
│   │   └── (can mirror Trgovine CSS here)
│   ├── js/
│   └── lib/
└── ... rest of project ...
```

## CSS File Loading Order

The CSS files load in this specific order (important for cascade):

```
1. Bootstrap CSS (from CDN)
2. Bootstrap Icons CSS (from CDN)
3. common.css (global styles)
4. Trgovine.css (shared store view styles)
5. Index.css / Details.css / Create.css (view-specific styles)
```

This ensures that view-specific styles override shared styles, and everything builds on the Bootstrap foundation.

## Alternative: Move CSS to wwwroot (Recommended for Production)

For better ASP.NET practices, optionally move CSS files to `wwwroot/css/`:

### Create directory structure:
```
wwwroot/
└── css/
    ├── common.css
    ├── Trgovine.css
    ├── Index.css
    ├── Details.css
    └── Create.css
```

### Update _Layout.cshtml:
```html
<!-- OcjenjivanjeTrgovina Custom CSS Files -->
<link rel="stylesheet" href="~/css/common.css">
<link rel="stylesheet" href="~/css/Trgovine.css">

@await RenderSectionAsync("ViewStyles", required: false)
```

### Update view @section:
```html
@section ViewStyles {
    <link rel="stylesheet" href="~/css/Index.css">
}
```

## Testing Checklist

After implementation, verify:

- [ ] All styling appears correctly on Index page (store listing)
- [ ] Store cards display in proper grid layout (3 columns on desktop)
- [ ] Store cards respond to hover (lift effect with shadow)
- [ ] Search and filter functionality works
- [ ] Details page displays correctly
- [ ] Forms display properly with validation styling
- [ ] Colors match the design (blues, reds, greens)
- [ ] Buttons have proper hover/active states
- [ ] Responsive design works (test with browser resize)
- [ ] Mobile layout works (test at 320px, 576px widths)
- [ ] All icons display (Bootstrap Icons)
- [ ] Print preview looks good
- [ ] No console errors in browser developer tools

## Responsive Testing Breakpoints

Test these widths to ensure responsive design:

| Device | Width | Test By |
|--------|-------|---------|
| Mobile Portrait | 320px | iPhone SE |
| Mobile Portrait | 375px | iPhone 12 |
| Mobile Landscape | 568px | iPhone SE landscape |
| Tablet Portrait | 768px | iPad |
| Tablet Landscape | 1024px | iPad landscape |
| Desktop | 1280px | Laptop |
| Desktop XL | 1920px | Desktop monitor |

Use browser DevTools (F12) → Device Toolbar to test these sizes.

## CSS Variables Customization

To customize colors globally, edit `common.css`:

```css
:root {
    --primary-color: #0d6efd;          /* Main brand color */
    --secondary-color: #6c757d;        /* Muted/secondary text */
    --success-color: #198754;          /* Success states */
    --danger-color: #dc3545;           /* Errors/delete */
    --warning-color: #ffc107;          /* Warnings/ratings */
    --info-color: #0dcaf0;             /* Info messages */
    --muted-color: #2c3e50;            /* Dark text/headers */
}
```

Change any value and ALL elements using that variable update automatically.

## Troubleshooting

### Issue: Styles not loading
**Solution:** 
- Check file paths in link tags (use `~/` for wwwroot reference)
- Verify CSS files exist in the correct directory
- Clear browser cache (Ctrl+Shift+Delete)
- Check browser console for 404 errors

### Issue: Bootstrap classes not working
**Solution:**
- Verify Bootstrap 5 CSS is linked before custom CSS
- Check that HTML elements have correct Bootstrap classes
- Ensure no CSS rule has `!important` that overrides Bootstrap

### Issue: Form validation styles don't show
**Solution:**
- Ensure Create.css is loaded for Create view
- Check that form control classes are applied
- Verify validation JavaScript is running

### Issue: Icons not showing (empty squares)
**Solution:**
- Ensure Bootstrap Icons CSS link is included
- Check that icon class names are correct (e.g., `bi bi-shop`)
- Verify icon font is loading (check Network tab in DevTools)

### Issue: Colors look different
**Solution:**
- Check if CSS variables were updated
- Verify browser is not in dark mode
- Check display color profile settings
- Test in different browser (Chrome, Firefox, Safari)

## Performance Tips

1. **Minimize CSS for Production:**
   ```bash
   # Use a CSS minifier to reduce file size
   common.css (9 KB) → common.min.css (5 KB)
   ```

2. **Cache Busting:**
   ```html
   <link rel="stylesheet" href="~/css/common.css?v=1.0">
   ```

3. **Lazy Load View-Specific Styles:**
   Keep view-specific CSS in `@section ViewStyles` to only load when needed.

4. **Bundle CSS (Optional):**
   Use ASP.NET bundling to combine CSS files:
   ```csharp
   // In BundleConfig.cs or Startup
   bundles.Add(new StyleBundle("~/bundles/css").Include(
       "~/css/common.css",
       "~/css/Trgovine.css"
   ));
   ```

## Browser Support

CSS works in:
- ✅ Chrome/Edge (last 2 versions)
- ✅ Firefox (last 2 versions)
- ✅ Safari (last 2 versions)
- ✅ Mobile browsers (iOS 12+, Android 8+)

**Not tested in:** IE 11 (not recommended)

## Next Steps

1. ✅ Copy CSS files to project
2. ✅ Update _Layout.cshtml
3. ✅ Update view files with @section ViewStyles
4. ✅ Remove inline `<style>` blocks from views
5. ✅ Test all pages and responsiveness
6. ✅ Clear browser cache and verify
7. ✅ Test across different browsers/devices
8. ✅ (Optional) Move CSS to wwwroot for production

## Questions & Support

For styling issues:
1. Check CSS_README.md for detailed documentation
2. Review comments in CSS files
3. Test using browser DevTools (F12)
4. Check Bootstrap 5 documentation: https://getbootstrap.com
5. Check Bootstrap Icons: https://icons.getbootstrap.com

## Files Summary

| File | Size | Purpose |
|------|------|---------|
| common.css | 9 KB | Global styles, variables, base components |
| Trgovine.css | 12 KB | Shared styles for all Trgovine views |
| Index.css | 8 KB | Store listing page specific styles |
| Details.css | 13 KB | Store details page specific styles |
| Create.css | 12 KB | Create store form specific styles |
| **Total** | **54 KB** | Complete styling solution |

---

**Implementation Date:** 2024
**CSS Framework:** Bootstrap 5.3.0 + Custom CSS
**Icons:** Bootstrap Icons 1.10.0
