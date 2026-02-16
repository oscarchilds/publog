# PubLog - Style Guide

**Version: 1.0**  
**Last Updated: February 15, 2026**

## Design Philosophy

PubLog uses a **dark mode-first** design with a modern, clean aesthetic inspired by contemporary web apps and SaaS products. The goal is a balanced design that looks professional and polished without being over-designed. Think: Vercel, Linear, Stripe - clean, functional, sophisticated.

**Key principle**: The design should feel like a modern tech product that happens to track pubs, not a pub-themed novelty app.

## Color Palette

### Primary Colors (Dark Mode)

```
Background (darkest):     #0f1419  (slate-950)
Surface (cards):          #1a1f2e  (slate-900)
Surface elevated:         #232936  (slate-800)
Border/divider:           #2d3748  (slate-700)
```

### Accent Colors

```
Primary accent (blue):    #3b82f6  (blue-500)   - Modern, tech-forward
Primary hover:            #2563eb  (blue-600)
Success (green):          #10b981  (emerald-500) - Visited/completed items
Success hover:            #059669  (emerald-600)
Secondary accent:         #8b5cf6  (violet-500)  - Optional for variety
```

### Text Colors

```
Primary text:             #f1f5f9  (slate-100)
Secondary text:           #cbd5e1  (slate-300)
Muted text:               #94a3b8  (slate-400)
Disabled text:            #64748b  (slate-500)
```

### Semantic Colors

```
Error:                    #ef4444  (red-500)
Warning:                  #f59e0b  (amber-500)
Info:                     #3b82f6  (blue-500)
Link:                     #60a5fa  (blue-400)
```

## Typography

### Font Family

```css
/* System font stack - fast, native, accessible */
font-family:
  -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue",
  Arial, sans-serif;
```

### Font Sizes (Tailwind classes)

```
Headings (H1):      text-3xl (30px)  font-bold
Headings (H2):      text-2xl (24px)  font-bold
Headings (H3):      text-xl (20px)   font-semibold
Body text:          text-base (16px) font-normal
Small text:         text-sm (14px)   font-normal
Tiny text:          text-xs (12px)   font-normal
Button text:        text-base (16px) font-medium
```

### Line Height

- Body text: `leading-relaxed` (1.625)
- Headings: `leading-tight` (1.25)

## Spacing System

Use Tailwind's spacing scale (4px base):

- **Tight spacing**: `gap-2` (8px) - Within cards, between related elements
- **Standard spacing**: `gap-4` (16px) - Between cards, sections
- **Loose spacing**: `gap-6` (24px) - Between major sections
- **Page padding**: `p-4` (16px) on mobile, `p-6` (24px) on tablet+

## Component Styles

### Cards

All content should be in card containers with consistent styling:

```html
<!-- Standard Card -->
<div class="bg-slate-900 rounded-lg shadow-lg p-4 border border-slate-700">
  <!-- Content -->
</div>

<!-- Elevated Card (interactive) -->
<div
  class="bg-slate-900 rounded-lg shadow-lg p-4 border border-slate-700 hover:bg-slate-800 hover:shadow-xl transition-all cursor-pointer"
>
  <!-- Content -->
</div>

<!-- Card with gradient accent (for featured content) -->
<div
  class="bg-gradient-to-br from-slate-900 to-slate-800 rounded-lg shadow-lg p-4 border border-slate-700"
>
  <!-- Content -->
</div>
```

### Buttons

**Primary Button (Main Actions):**

```html
<button
  class="bg-blue-500 hover:bg-blue-600 text-white font-medium px-6 py-3 rounded-lg shadow-md hover:shadow-lg transition-all"
>
  Mark as Visited
</button>
```

**Secondary Button:**

```html
<button
  class="bg-slate-800 hover:bg-slate-700 text-slate-100 font-medium px-6 py-3 rounded-lg border border-slate-600 hover:border-slate-500 transition-all"
>
  Cancel
</button>
```

**Success Button (for visited items):**

```html
<button
  class="bg-emerald-500 hover:bg-emerald-600 text-white font-medium px-6 py-3 rounded-lg shadow-md transition-all"
>
  Update Visit
</button>
```

**Danger Button (Delete):**

```html
<button
  class="bg-red-500 hover:bg-red-600 text-white font-medium px-4 py-2 rounded-lg transition-all"
>
  Delete
</button>
```

**Ghost Button (subtle):**

```html
<button
  class="text-slate-400 hover:text-slate-200 font-medium px-4 py-2 transition-all"
>
  Learn More
</button>
```

**Icon Button (small actions):**

```html
<button
  class="w-10 h-10 flex items-center justify-center bg-slate-800 hover:bg-slate-700 rounded-lg border border-slate-600 transition-all"
>
  <svg><!-- icon --></svg>
</button>
```

### Form Inputs

**Text Input:**

```html
<input
  type="text"
  class="w-full bg-slate-800 text-slate-100 border border-slate-600 rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent placeholder-slate-400"
  placeholder="Search..."
/>
```

**Textarea:**

```html
<textarea
  class="w-full bg-slate-800 text-slate-100 border border-slate-600 rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent placeholder-slate-400 resize-none"
  rows="4"
  placeholder="Add your notes..."
></textarea>
```

**Select Dropdown:**

```html
<select
  class="w-full bg-slate-800 text-slate-100 border border-slate-600 rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
>
  <option>Select area...</option>
</select>
```

### Badges & Tags

**Visited Badge:**

```html
<span
  class="inline-flex items-center px-3 py-1 rounded-full text-xs font-medium bg-emerald-500/20 text-emerald-400 border border-emerald-500/30"
>
  ✓ Visited
</span>
```

**Role Badge (Admin):**

```html
<span
  class="inline-flex items-center px-3 py-1 rounded-full text-xs font-medium bg-blue-500/20 text-blue-400 border border-blue-500/30"
>
  Admin
</span>
```

**Info Badge:**

```html
<span
  class="inline-flex items-center px-3 py-1 rounded-full text-xs font-medium bg-slate-700 text-slate-300 border border-slate-600"
>
  New
</span>
```

**Count Badge:**

```html
<span
  class="inline-flex items-center justify-center w-6 h-6 rounded-full text-xs font-bold bg-slate-700 text-slate-200"
>
  12
</span>
```

### Progress Bar

```html
<div class="w-full bg-slate-800 rounded-full h-2 overflow-hidden">
  <div
    class="bg-gradient-to-r from-blue-500 to-blue-400 h-full rounded-full transition-all"
    style="width: 65%"
  ></div>
</div>

<!-- With label -->
<div class="space-y-2">
  <div class="flex justify-between text-sm text-slate-300">
    <span>Progress</span>
    <span class="font-medium">12 of 18 items</span>
  </div>
  <div class="w-full bg-slate-800 rounded-full h-2 overflow-hidden">
    <div
      class="bg-gradient-to-r from-blue-500 to-blue-400 h-full rounded-full transition-all"
      style="width: 67%"
    ></div>
  </div>
</div>
```

### Navigation

**Bottom Navigation Bar (Mobile):**

```html
<nav
  class="fixed bottom-0 left-0 right-0 bg-slate-900 border-t border-slate-700 px-4 py-3 flex justify-around items-center shadow-lg"
>
  <a href="/" class="flex flex-col items-center gap-1 text-blue-500">
    <svg class="w-6 h-6"><!-- icon --></svg>
    <span class="text-xs font-medium">Home</span>
  </a>
  <a
    href="/profile"
    class="flex flex-col items-center gap-1 text-slate-400 hover:text-slate-200"
  >
    <svg class="w-6 h-6"><!-- icon --></svg>
    <span class="text-xs font-medium">Profile</span>
  </a>
</nav>
```

**Top Navigation Bar (Desktop):**

```html
<nav class="bg-slate-900 border-b border-slate-700 px-6 py-4">
  <div class="max-w-7xl mx-auto flex justify-between items-center">
    <h1 class="text-2xl font-bold text-slate-100">PubLog</h1>
    <div class="flex items-center gap-4">
      <span class="text-slate-400"
        >Welcome, <span class="text-slate-100 font-medium">Username</span></span
      >
      <button class="text-slate-400 hover:text-slate-200 transition-colors">
        Logout
      </button>
    </div>
  </div>
</nav>
```

## Page-Specific Layouts

### Homepage (Area List)

```html
<div class="min-h-screen bg-slate-950 pb-20">
  <!-- pb-20 for bottom nav clearance -->
  <!-- Header -->
  <div
    class="bg-gradient-to-b from-slate-900 to-slate-950 px-4 py-6 border-b border-slate-800"
  >
    <h1 class="text-3xl font-bold text-slate-100 mb-2">PubLog</h1>
    <p class="text-slate-400">Track your visits and discoveries</p>
  </div>

  <!-- Search Bar -->
  <div class="px-4 py-4">
    <input
      type="text"
      class="w-full bg-slate-800 text-slate-100 border border-slate-600 rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
      placeholder="Search areas..."
    />
  </div>

  <!-- Area Cards -->
  <div class="px-4 space-y-3">
    <!-- Area Card -->
    <a
      href="/areas/1"
      class="block bg-slate-900 rounded-lg shadow-lg p-4 border border-slate-700 hover:bg-slate-800 hover:shadow-xl transition-all"
    >
      <div class="flex justify-between items-start">
        <div>
          <h3 class="text-lg font-semibold text-slate-100">Manchester</h3>
          <p class="text-sm text-slate-400 mt-1">24 locations</p>
        </div>
        <span
          class="inline-flex items-center px-3 py-1 rounded-full text-xs font-medium bg-blue-500/20 text-blue-400"
        >
          12 visited
        </span>
      </div>

      <!-- Progress bar -->
      <div class="mt-3">
        <div class="w-full bg-slate-800 rounded-full h-1.5 overflow-hidden">
          <div
            class="bg-blue-500 h-full rounded-full transition-all"
            style="width: 50%"
          ></div>
        </div>
      </div>
    </a>
  </div>
</div>
```

### Area Page (List View)

```html
<div class="min-h-screen bg-slate-950">
  <!-- Header with back button -->
  <div
    class="bg-slate-900 border-b border-slate-700 px-4 py-4 sticky top-0 z-10"
  >
    <div class="flex items-center gap-3">
      <button
        class="w-10 h-10 flex items-center justify-center bg-slate-800 rounded-lg hover:bg-slate-700 transition-colors"
      >
        ←
        <!-- Back icon -->
      </button>
      <div class="flex-1">
        <h1 class="text-xl font-bold text-slate-100">Manchester</h1>
        <p class="text-sm text-slate-400">24 locations • 12 visited</p>
      </div>
    </div>

    <!-- Progress -->
    <div class="mt-3">
      <div class="w-full bg-slate-800 rounded-full h-2 overflow-hidden">
        <div
          class="bg-gradient-to-r from-blue-500 to-blue-400 h-full rounded-full transition-all"
          style="width: 50%"
        ></div>
      </div>
    </div>
  </div>

  <!-- View Toggle -->
  <div class="px-4 py-3 bg-slate-900/50 border-b border-slate-800">
    <div class="inline-flex rounded-lg bg-slate-800 p-1">
      <button
        class="px-4 py-2 rounded-md bg-blue-500 text-white font-medium text-sm transition-colors"
      >
        List
      </button>
      <button
        class="px-4 py-2 rounded-md text-slate-400 font-medium text-sm hover:text-slate-200 transition-colors"
      >
        Map
      </button>
    </div>
  </div>

  <!-- Item Cards -->
  <div class="px-4 py-4 space-y-3">
    <a
      href="/pubs/1"
      class="block bg-slate-900 rounded-lg shadow-lg p-4 border border-slate-700 hover:bg-slate-800 transition-all"
    >
      <div class="flex items-start gap-3">
        <!-- Visited indicator -->
        <div
          class="w-3 h-3 rounded-full bg-emerald-500 mt-1.5 flex-shrink-0"
        ></div>

        <div class="flex-1 min-w-0">
          <h3 class="text-base font-semibold text-slate-100">The Red Lion</h3>
          <p class="text-sm text-slate-400 mt-1 line-clamp-2">
            Traditional establishment with great atmosphere and local selection
          </p>

          <div class="flex items-center gap-4 mt-3 text-xs text-slate-500">
            <span>15 visits</span>
            <span>•</span>
            <span>Last visited: Jan 15, 2026</span>
          </div>
        </div>

        <svg class="w-5 h-5 text-slate-600 flex-shrink-0">
          <!-- chevron right -->
        </svg>
      </div>
    </a>
  </div>
</div>
```

### Detail Page

```html
<div class="min-h-screen bg-slate-950">
  <!-- Hero Image (if available) -->
  <div class="relative h-48 bg-slate-800 overflow-hidden">
    <img
      src="location-image.jpg"
      class="w-full h-full object-cover opacity-80"
      alt="Location"
    />
    <div
      class="absolute inset-0 bg-gradient-to-t from-slate-950 to-transparent"
    ></div>

    <!-- Back button overlay -->
    <button
      class="absolute top-4 left-4 w-10 h-10 flex items-center justify-center bg-slate-900/80 backdrop-blur-sm rounded-lg border border-slate-700 hover:bg-slate-800 transition-colors"
    >
      ←
    </button>
  </div>

  <!-- Content -->
  <div class="px-4 py-4 space-y-4">
    <!-- Info Card -->
    <div
      class="bg-slate-900 rounded-lg shadow-lg p-5 border border-slate-700 -mt-8 relative z-10"
    >
      <h1 class="text-2xl font-bold text-slate-100 mb-2">The Red Lion</h1>
      <p class="text-slate-400 mb-4">
        Traditional establishment with great atmosphere and curated selection
      </p>

      <div class="flex items-center gap-2 text-sm text-slate-500 mb-4">
        <svg class="w-4 h-4"><!-- location icon --></svg>
        <span>45 High Street, Manchester, UK</span>
      </div>

      <!-- Action Buttons -->
      <div class="flex gap-2">
        <button
          class="flex-1 bg-emerald-500 hover:bg-emerald-600 text-white font-medium px-4 py-3 rounded-lg transition-colors"
        >
          Update Visit
        </button>
        <button
          class="w-12 h-12 flex items-center justify-center bg-slate-800 hover:bg-slate-700 rounded-lg border border-slate-600 transition-colors"
        >
          📍
        </button>
        <button
          class="w-12 h-12 flex items-center justify-center bg-slate-800 hover:bg-slate-700 rounded-lg border border-slate-600 transition-colors"
        >
          ℹ️
        </button>
      </div>
    </div>

    <!-- Map Card -->
    <div
      class="bg-slate-900 rounded-lg shadow-lg overflow-hidden border border-slate-700"
    >
      <div class="h-48 bg-slate-800">
        <!-- Leaflet map here -->
      </div>
    </div>

    <!-- Visits Section -->
    <div class="bg-slate-900 rounded-lg shadow-lg p-5 border border-slate-700">
      <h2 class="text-lg font-semibold text-slate-100 mb-4">Recent Visits</h2>

      <div class="space-y-4">
        <!-- Visit Item -->
        <div class="border-l-2 border-blue-500 pl-4 py-2">
          <div class="flex justify-between items-start mb-2">
            <span class="font-medium text-slate-200">JohnDoe</span>
            <span class="text-sm text-slate-500">Jan 15, 2026</span>
          </div>
          <p class="text-sm text-slate-400">
            Great selection and friendly service. Highly recommended!
          </p>
        </div>

        <div class="border-l-2 border-slate-700 pl-4 py-2">
          <div class="flex justify-between items-start mb-2">
            <span class="font-medium text-slate-200">AliceSmith</span>
            <span class="text-sm text-slate-500">Dec 20, 2025</span>
          </div>
          <p class="text-sm text-slate-400">
            Cozy atmosphere, perfect for winter evenings.
          </p>
        </div>
      </div>
    </div>
  </div>
</div>
```

## Visual Enhancements

### Shadows

Use Tailwind's shadow utilities for depth:

- Cards: `shadow-lg`
- Buttons (hover): `shadow-xl`
- Bottom nav: `shadow-2xl`

### Transitions

Always animate state changes:

```css
transition-all duration-200
```

Common transitions:

- Button hover states
- Card hover states
- Page transitions (use Blazor's built-in transition support)

### Gradients

Use sparingly for accents:

```html
<!-- Subtle background gradient -->
<div class="bg-gradient-to-b from-slate-900 to-slate-950">
  <!-- Progress bar gradient -->
  <div class="bg-gradient-to-r from-blue-500 to-blue-400">
    <!-- Button gradient (optional enhancement) -->
    <div class="bg-gradient-to-r from-blue-500 to-violet-500">
      <!-- Card accent -->
      <div class="bg-gradient-to-br from-slate-900 to-slate-800"></div>
    </div>
  </div>
</div>
```

### Icons

- Use **Heroicons** (https://heroicons.com/) or **Lucide** (https://lucide.dev/)
- Keep icons monochrome (inherit text color)
- Size: `w-5 h-5` for inline icons, `w-6 h-6` for nav icons

## Responsive Breakpoints

```
Mobile:     < 640px   (default)
Tablet:     640px+    (sm:)
Desktop:    1024px+   (lg:)
Wide:       1280px+   (xl:)
```

### Mobile-First Approach

Always design for mobile first, then enhance for larger screens:

```html
<!-- Mobile: full width, Desktop: max width centered -->
<div class="w-full lg:max-w-4xl lg:mx-auto">
  <!-- Mobile: stack, Desktop: side by side -->
  <div class="flex flex-col lg:flex-row gap-4">
    <!-- Mobile: small text, Desktop: larger -->
    <h1 class="text-2xl lg:text-4xl"></h1>
  </div>
</div>
```

## Accessibility

- **Contrast**: All text must meet WCAG AA standards (already met with these color choices)
- **Focus states**: Always visible with `focus:ring-2 focus:ring-blue-500`
- **Touch targets**: Minimum 44x44px (`min-h-11 min-w-11` or `p-3`)
- **Labels**: All form inputs must have labels (can be `sr-only` if visual label not needed)
- **Keyboard navigation**: All interactive elements must be keyboard accessible

## Loading States

```html
<!-- Skeleton loader for cards -->
<div class="bg-slate-900 rounded-lg p-4 border border-slate-700 animate-pulse">
  <div class="h-4 bg-slate-800 rounded w-3/4 mb-3"></div>
  <div class="h-3 bg-slate-800 rounded w-1/2"></div>
</div>

<!-- Loading spinner -->
<div class="flex items-center justify-center p-8">
  <div
    class="w-8 h-8 border-4 border-slate-700 border-t-blue-500 rounded-full animate-spin"
  ></div>
</div>
```

## Empty States

```html
<div class="bg-slate-900 rounded-lg p-8 border border-slate-700 text-center">
  <svg class="w-16 h-16 mx-auto mb-4 text-slate-600"><!-- icon --></svg>
  <h3 class="text-lg font-semibold text-slate-300 mb-2">No items yet</h3>
  <p class="text-slate-500 mb-4">
    Start by adding your first item to this area
  </p>
  <button
    class="bg-blue-500 hover:bg-blue-600 text-white font-medium px-6 py-2 rounded-lg transition-colors"
  >
    Add Item
  </button>
</div>
```

## Do's and Don'ts

### ✅ Do:

- Use consistent spacing (stick to 4px multiples)
- Keep cards elevated with subtle shadows
- Use amber accent sparingly for important actions
- Animate state changes smoothly
- Maintain dark backgrounds throughout

### ❌ Don't:

- Don't use pure white (`#ffffff`) - use `slate-100` instead
- Don't use pure black (`#000000`) - use `slate-950` instead
- Don't over-use gradients - keep it subtle
- Don't create tiny touch targets on mobile
- Don't use more than 2-3 accent colors per screen

## Implementation Notes

- All Tailwind classes should be applied directly in Blazor `.razor` files
- Use `@apply` in CSS only for repeated complex combinations
- Leverage Tailwind's dark mode utilities if implementing light mode later
- Test on real devices - dark mode can look different on OLED vs LCD screens

---

**Remember**: The goal is a sleek, modern dark theme that feels like a professional SaaS product. The blue accent is clean and tech-forward. The design should work just as well for tracking _anything_ - it just happens to be tracking pubs.

**Design inspiration**: Vercel, Linear, Stripe, GitHub (dark mode)
