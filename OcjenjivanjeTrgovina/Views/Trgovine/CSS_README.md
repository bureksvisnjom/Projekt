# CSS Files Documentation

## Overview

This directory contains comprehensive CSS files created for the **OcjenjivanjeTrgovina** ASP.NET Core MVC application. The CSS is organized to style the Trgovine (Store) views with a modular, maintainable approach.

## File Structure

```
Views/Trgovine/
├── Index.cshtml          # Store listing page
├── Index.css             # Styles for Index view (specific)
├── Details.cshtml        # Store details page
├── Details.css           # Styles for Details view (specific)
├── Create.cshtml         # Create store form page
├── Create.css            # Styles for Create view (specific)
├── Trgovine.css          # Shared styles for all Trgovine views
├── common.css            # Global shared styles across entire application
└── CSS_README.md         # This file
```

## CSS Files Description

### 1. **common.css** (9 KB)
**Purpose:** Global, reusable styles for the entire application

**Contains:**
- CSS Custom Properties (variables) for colors, spacing, and transitions
- Global typography styles
- Card component styles
- Button styles (all variants: primary, outline, warning, danger)
- Form control styles (inputs, selects, labels)
- Badge and breadcrumb styles
- Alert box styles
- Progress bar styles
- Responsive breakpoints (992px, 768px, 576px)

**Key Variables:**
```css
--primary-color: #0d6efd
--secondary-color: #6c757d
--success-color: #198754
--danger-color: #dc3545
--warning-color: #ffc107
--radius-lg: 12px
--transition-normal: 0.3s ease
```

### 2. **Trgovine.css** (12 KB)
**Purpose:** Shared styles specific to all Trgovine-related views

**Contains:**
- Store card grid layouts
- Store details sections with icons
- Statistics display styles
- Rating/star display styles
- Breadcrumb specific styling
- Form-related components
- Responsive grid system for different screen sizes
- Animations for store cards
- Utility classes for store management

**Key Features:**
- Dynamic grid that adapts from 3 columns (desktop) → 2 columns (tablet) → 1 column (mobile)
- Hover effects with smooth transitions
- Card elevation on hover
- Icon integration with Bootstrap Icons (bi)
- Search and filter styling
- Responsive breakpoints for tablets and phones

### 3. **Index.css** (8 KB)
**Purpose:** Specific styles for the Store Listing (Index) view

**Contains:**
- Page header styling with title and description
- "Create Store" button styling
- Search input styling with icon integration
- Filter dropdown styling
- Store cards grid layout
- Empty state styling
- Pagination info styling
- Animations for card entrance
- Accessibility focus states
- Print styles

**Key Components:**
- Search bar with magnifying glass icon
- City filter dropdown
- Responsive grid of store cards
- Empty state message when no stores exist

### 4. **Details.css** (13 KB)
**Purpose:** Specific styles for the Store Details page

**Contains:**
- Breadcrumb navigation styling
- Store header card with badge
- Information grid (location, contact, opening date)
- Statistics cards (products count, ratings count)
- Rating section with star display and progress bar
- Sidebar action buttons (Back, Edit, Delete)
- Quick stats panel
- Info alert box
- Products grid section
- Not found/error state styling

**Key Features:**
- Two-column layout (content + sidebar)
- Responsive breakpoints for tablet/mobile
- Star rating visualization
- Progress bar for rating percentage
- Product cards in a 3-column grid
- Badge for store status

### 5. **Create.css** (12 KB)
**Purpose:** Specific styles for the Store Creation Form page

**Contains:**
- Form card styling
- Form group and label styling
- Input and select control styling with focus states
- Form validation messages and error styling
- Validation summary alert styling
- Form action buttons (Submit/Cancel)
- Info alert about required fields
- Responsive form layout
- Form animations and transitions
- Accessibility features for keyboard navigation
- Print styles

**Key Features:**
- Centered form layout
- Clear validation error messages
- Required field indicators
- Focus state animations
- Submit button with hover effects
- Cancel button styling

## How to Implement

### Step 1: Reference CSS Files in Layout or Views

Add these links to your `_Layout.cshtml` or individual view files within the `<head>` section:

```html
<!-- Common Styles (must be first) -->
<link rel="stylesheet" href="~/Views/Trgovine/common.css">

<!-- Trgovine Shared Styles -->
<link rel="stylesheet" href="~/Views/Trgovine/Trgovine.css">

<!-- View-Specific Styles (choose one) -->
<link rel="stylesheet" href="~/Views/Trgovine/Index.css">       <!-- For Index view -->
<link rel="stylesheet" href="~/Views/Trgovine/Details.css">     <!-- For Details view -->
<link rel="stylesheet" href="~/Views/Trgovine/Create.css">      <!-- For Create view -->
```

### Step 2: Ensure Bootstrap 5 and Bootstrap Icons are included

The CSS files use Bootstrap 5 classes and Bootstrap Icons. Make sure your `_Layout.cshtml` includes:

```html
<!-- Bootstrap 5 CSS -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">

<!-- Bootstrap Icons -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.0/font/bootstrap-icons.css">

<!-- Bootstrap 5 JS (for interactive components) -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
```

### Step 3: Remove Inline Styles from CSHTML Files

Once CSS files are linked, you can remove the `<style>` blocks from the CSHTML files to keep code clean and maintainable.

**Before (with inline CSS):**
```html
<div class="card" style="...">
    <!-- content -->
</div>

<style>
    .card { ... }
</style>
```

**After (with external CSS):**
```html
<div class="card">
    <!-- content -->
</div>
```

## Color Scheme

| Color | Hex Code | Usage |
|-------|----------|-------|
| Primary | #0d6efd | Buttons, links, active states |
| Secondary | #6c757d | Text, muted content |
| Success | #198754 | Badges, success messages |
| Danger | #dc3545 | Error messages, delete actions |
| Warning | #ffc107 | Warnings, ratings (stars) |
| Info | #0dcaf0 | Info alerts |
| Light | #f8f9fa | Backgrounds, cards |
| Dark | #212529 | Primary text |
| Muted | #2c3e50 | Headers, emphasis text |

## Responsive Breakpoints

CSS follows Bootstrap 5 breakpoint system:

| Device | Width | CSS |
|--------|-------|-----|
| Extra Large Desktop | ≥1200px | Default styles |
| Large Tablet | 992px - 1199px | `@media (max-width: 991px)` |
| Medium Tablet | 768px - 991px | `@media (max-width: 768px)` |
| Small Mobile | 576px - 767px | `@media (max-width: 576px)` |
| Extra Small | <576px | `@media (max-width: 360px)` |

## Component Examples

### Search Input
```html
<div class="input-group input-group-lg">
    <span class="input-group-text bg-light border-0">
        <i class="bi bi-search"></i>
    </span>
    <input type="text" class="form-control" placeholder="Search...">
</div>
```

### Store Card
```html
<div class="card h-100 shadow-sm border-0 transition">
    <div class="card-body">
        <h5 class="card-title">Store Name</h5>
        <p><i class="bi bi-geo-alt text-danger"></i> Address</p>
    </div>
</div>
```

### Action Button Group
```html
<div class="btn-group">
    <a href="#" class="btn btn-outline-secondary btn-sm flex-grow-1">
        <i class="bi bi-pencil"></i> Edit
    </a>
    <a href="#" class="btn btn-outline-danger btn-sm flex-grow-1">
        <i class="bi bi-trash"></i> Delete
    </a>
</div>
```

### Form Group
```html
<div class="mb-4">
    <label asp-for="Naziv" class="form-label fw-bold">
        <i class="bi bi-shop"></i> Store Name
    </label>
    <input asp-for="Naziv" class="form-control form-control-lg" required>
    <span asp-validation-for="Naziv" class="text-danger small"></span>
    <small class="form-text text-muted">Enter store name</small>
</div>
```

## CSS Cascade Order

To ensure proper styling, load files in this order:

1. **common.css** - Global base styles and variables
2. **Trgovine.css** - Shared component styles for Trgovine views
3. **Index.css / Details.css / Create.css** - View-specific styles

This cascading ensures that:
- View-specific styles override shared styles
- Shared styles override global styles
- Global styles provide base consistency

## Customization

### Change Primary Color

Edit `common.css`:
```css
:root {
    --primary-color: #0d6efd;  /* Change this hex code */
}
```

This single change will update all primary colored elements throughout the application.

### Adjust Border Radius

Edit `common.css`:
```css
:root {
    --radius-lg: 12px;  /* Make corners more/less rounded */
}
```

### Modify Transition Speed

Edit `common.css`:
```css
:root {
    --transition-normal: 0.3s ease;  /* Change speed */
}
```

## Browser Compatibility

CSS files are compatible with:
- Chrome/Chromium (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)
- Mobile browsers (iOS Safari, Chrome Mobile)

**Features Used:**
- CSS Grid
- CSS Flexbox
- CSS Custom Properties (variables)
- CSS Transitions and Animations
- Media Queries
- RGBA Colors

## Performance Optimization

### Current File Sizes
- common.css: ~9 KB
- Trgovine.css: ~12 KB
- Index.css: ~8 KB
- Details.css: ~13 KB
- Create.css: ~12 KB

**Total:** ~54 KB (unminified)

### For Production
Consider minifying CSS files:
```bash
# Using any CSS minifier tool
common.css → common.min.css  (~5 KB)
Trgovine.css → Trgovine.min.css  (~7 KB)
```

Update links:
```html
<link rel="stylesheet" href="~/Views/Trgovine/common.min.css">
```

## Accessibility Features

CSS includes:
- ✅ Focus states for keyboard navigation
- ✅ Sufficient color contrast ratios (WCAG AA compliant)
- ✅ Visible focus indicators on interactive elements
- ✅ Semantic HTML with appropriate ARIA attributes
- ✅ Print-friendly styles
- ✅ Responsive design for all screen sizes

## Known Limitations & Notes

1. **Icon Library:** Files use Bootstrap Icons (bi). Ensure `bootstrap-icons.css` is linked.
2. **Bootstrap Dependency:** Files rely on Bootstrap 5 utilities and classes.
3. **Inline Styles:** CSHTML files contain inline styles in `<style>` blocks that can be removed once external CSS is properly linked.
4. **JavaScript Interactions:** Some features (form validation, filtering) require JavaScript from the CSHTML files.

## Support & Maintenance

When updating styles:

1. Test changes across different screen sizes
2. Check form validation and interactions still work
3. Test keyboard navigation (Tab key)
4. Verify color contrast for accessibility
5. Test in multiple browsers
6. Check print preview appearance

## Future Improvements

Consider these enhancements:
- [ ] Extract CSS to proper `wwwroot/css/` directory
- [ ] Create separate CSS file for dark mode theme
- [ ] Add animations library integration
- [ ] Create CSS component library documentation
- [ ] Add unit tests for critical styles
- [ ] Implement CSS-in-JS solution if needed for dynamic theming

---

**Last Updated:** 2024
**CSS Version:** 1.0
**Bootstrap Version:** 5.3.0
**Bootstrap Icons Version:** 1.10.0
