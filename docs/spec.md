# PubLog - Application Specification

**Version: 1.0**  
**Date: February 15, 2026**  
**Status: Ready for Development**

---

## Background

This specification was created through an interactive conversation between the project owner and Claude (Anthropic's AI assistant) on February 15, 2026. The spec was developed iteratively through:

- Initial requirements gathering and clarification questions
- Discussion of technical decisions (database, hosting, frameworks)
- UI/UX considerations for mobile-first design
- Role-based access control definition
- Feature prioritization and phasing

All major technical and functional decisions were made collaboratively, with the project owner making final choices on:

- Technology stack (Blazor Server, Azure SQL, Tailwind CSS)
- User roles and permissions (Anonymous, User, Admin)
- Navigation flow and page structure
- Visit tracking model (single visit per user per pub)
- Deployment strategy (direct to production)

This spec is intended for use with Claude Code or any development team to build the application.

---

## Overview

A mobile-friendly Blazor web application for tracking pub visits across multiple areas. The app enables a small group of friends to catalog pubs by area, track their visits with notes, and view pub locations on a map.

## Target Users

- Small private group (project owner + friends)
- Primary access via mobile devices
- Read-only access for non-authenticated users
- Admin access for authenticated users

## Technology Stack

- **.NET 10**
- **Blazor Server** (server-side rendering)
- **Entity Framework Core** for data access
  - **EF Migrations** for database schema management
- **Database**: Azure SQL Database Basic tier ($5/month fixed)
- **Map Display**: Leaflet.js with OpenStreetMap (free)
- **UI Framework**: Tailwind CSS for styling
- **Authentication**: Simple cookie-based auth with password hashing
- **Monitoring**: Azure Application Insights (free tier)
- **SSL/HTTPS**: Enforced (free SSL via Azure App Service)
- **Source Control**: GitHub
- **CI/CD**: GitHub Actions

## Data Model

### Core Entities

- **User**: Username, password (hashed), display name, role (User/Admin)
- **Area**: Name
- **Pub**: Name, description, address, coordinates (lat/long), image URL, belongs to an Area
- **Visit**: User's record of visiting a Pub - stores last visit date and notes (one record per user per pub)

### Relationships

- Area has many Pubs
- Pub has many Visits (one per user)
- User has many Visits (one per pub)
- Users can see all other users' visits

## Functional Requirements

### Authentication

- Simple username/password login (cookie-based)
- Passwords hashed and stored securely
- No self-registration - users created manually by admin
- **Initial admin account**: Seeded in code with default password (to be changed after first login)
- **User roles:**
  - **Anonymous**: Read-only access (browse areas, pubs, view all visits)
  - **User**: Can mark pubs as visited, update own visits, view all content
  - **Admin**: Full access - can manage areas, pubs, users, and track visits

### Core Features

**1. Browse Areas (All Users)**

- Homepage shows list of all areas alphabetically
- Search areas by name
- Each area shows pub count and visit progress (if logged in)
- Click area to view its pubs

**2. Browse Pubs (All Users)**

- Area page shows pubs in that area
- **Sorting**: Pubs sorted by total visit count (most visited first)
- **Progress indicator** (logged-in users): Show "X of Y pubs visited" with visual progress bar
- Toggle between List View and Map View
- Search pubs by name (within current area)
- Filter by visited/unvisited, date visited (logged-in users only)
- Click pub to view details

**3. View Pub Details (All Users)**

- Show pub name, image (from URL if provided), description, address
- Embedded map showing location
- "Open in Google Maps" and "Open in TripAdvisor" buttons
- Display all users' visit records with dates and notes
- Logged-in users (User + Admin) see "Mark as Visited" or "Update Visit" button
- Admins only see Edit Pub and Delete Pub buttons

**4. Manage Areas (Admin Only)**

- Add, edit, delete areas via admin interface
- Validation: Name required, unique

**5. Manage Pubs (Admin Only)**

- Add pub: Name, description, address, latitude, longitude, image URL (optional), area dropdown
- Coordinates (lat/long) entered manually by admin
  - Admin can get coordinates by right-clicking location in Google Maps
- Edit/delete any pub
- Image URL: User pastes link to online image (no file upload)

**6. Track Visits (Logged-in Users: User + Admin roles)**

- Mark a pub as visited from Pub Detail page
- Record includes: last visit date (defaults to today) + optional notes (notes are completely optional)
- Each user can only have one visit record per pub
- Updating visit: Change the date and/or update notes (replaces previous)
- View all own visits on Profile/My Visits page
- Delete own visit record (marks pub as unvisited)
- See all users' visit records on each pub's detail page

**7. User Management (Admin Only)**

- Manually create user accounts with role assignment (User or Admin)
- Basic user list showing username, display name, and role
- Deactivate/reactivate users
- Cannot delete users (deactivation only to preserve visit history)

## Non-Functional Requirements

- **Mobile-First**: Optimized for 320px-428px screens, touch-friendly (44px min targets)
- **Performance**: Lazy loading, pagination, map marker clustering
- **Security**: HTTPS, hashed passwords, server-side validation, authentication required for all write operations
- **Usability**: Clear errors, loading indicators, confirmation dialogs for deletes

## User Interface

### Navigation Flow

```
Homepage (Area List) → Area Page (Pub List/Map) → Pub Detail Page
```

### Key Pages

**1. Homepage** (`/`)

- List of all areas (alphabetically sorted)
- Search bar
- Each area card shows: name, pub count, visited count (if logged in)
- Mobile-friendly cards

**2. Area Page** (`/areas/{id}`)

- Header: Area name, back button
- Toggle: List View / Map View
- Search and filter pubs (by name, visited status, date)
- List: Cards with pub name, description, visited indicator
- Map: Markers (blue=unvisited, green=visited)

**3. Pub Detail Page** (`/pubs/{id}`)

- Pub name, image (from URL if provided), description, address
- Embedded map
- Action buttons:
  - "Open in Google Maps" (links to Google Maps with coordinates)
  - "Open in TripAdvisor" (searches TripAdvisor for pub name + area)
- List of all users' visit records (username, last visit date, notes)
- Admin buttons (if logged in): "Mark as Visited" or "Update Visit" (if already visited), Edit Pub, Delete Pub

**4. Mark/Update Visit Page** (`/pubs/{id}/visit`)

- Date picker (defaults to today)
- Notes textarea (optional)
- If updating: Pre-filled with existing date and notes
- Save/Cancel buttons
- Delete Visit button (if updating existing visit)

**5. Profile Page** (`/profile`)

- User stats (pubs visited, total visits)
- Recent visits list
- Link to "My Visits" page

**6. My Visits Page** (`/visits`)

- List of all pubs user has visited (one entry per pub)
- Shows: pub name, area, last visit date, notes
- Filters: date range, area, pub name
- Update/Delete buttons per visit record

**7. Admin Pages** (Structure TBD)

- Admin dashboard
- Manage areas
- Add/Edit pub form
- Manage users

### Mobile-First Design

- Touch-friendly buttons (min 44x44px)
- Bottom or hamburger navigation
- Card-based layouts
- Responsive breakpoints
- Fast load times
- **PWA features**:
  - Custom app icon and favicon
  - Proper app name for home screen installation
  - Optimized for "Add to Home Screen" experience

## Development Setup

### Required Software

- **.NET 10 SDK**
- **Code Editor**: Visual Studio 2022, VS Code with C# Dev Kit, or JetBrains Rider
- **SQL Server**: SQL Server Express or SQL Server LocalDB (comes with Visual Studio)
- **Git** for source control

### Database Development

- **Local SQL Server** for development (SQL Server Express or LocalDB)
- Separate connection strings for Development and Production environments
- Development database runs locally, Production uses Azure SQL Database
- EF Migrations manage schema in both environments

### Entity Framework Migrations

- Use EF Core Migrations for all database schema changes
- Initial migration will create tables for User, Area, Pub, Visit entities
- Migration workflow:
  1. Create migration: `dotnet ef migrations add MigrationName`
  2. Apply to database: `dotnet ef database update`
  3. Commit migration files to Git
- Seed initial admin account in migration or startup configuration
- CI/CD pipeline should apply pending migrations on deployment (or run manually before deploy)

## Deployment

### Hosting

- **Azure App Service** - Free F1 tier or Basic B1 (~$13/month) depending on performance needs
- **Database**: Azure SQL Database Basic tier ($5/month fixed)
- **Environment**: Single production environment (no separate dev/staging)

### CI/CD with GitHub Actions

- Automated build and test on pull requests
- Automated deployment to production on merge to main branch
- Secrets managed via GitHub Secrets (database connection strings, API keys)

### Application Name

- **PubLog**
- Name will be used for: browser title, mobile app icon label, home screen name, GitHub repository

### Estimated Monthly Costs

- **Minimum**: Azure App Service Free (F1) + Azure SQL Basic = **$5/month**
- **Recommended**: Azure App Service Basic (B1) + Azure SQL Basic = **~$18/month** (better performance)

## Development Phases

### Phase 1: Foundation (MVP)

- Set up Blazor project with authentication
- Implement database models and EF Core context
- Create user management (manual user creation via seed data or basic admin page)
- Build area CRUD
- Build pub CRUD with manual lat/long entry
- **Implement core sitemap**:
  - Homepage: Area list (alphabetically sorted)
  - Area Page: Pub list view AND map view with toggle
  - Pub Detail Page: Basic info display

### Phase 2: Core Features

- Implement visit tracking (mark as visited, update, delete)
  - Mark pub as visited from Pub Detail Page
  - Update existing visit record (date and notes)
  - Display all users' visit records on Pub Detail Page
- Add search and filters on Area Page
- Build Profile page with user statistics
- Build My Visits page

### Phase 3: Polish & Enhancement

- Polish mobile UI (responsive design, touch-friendly)
- Add loading states and error handling
- Implement breadcrumb navigation
- Performance optimization (lazy loading, caching)

### Phase 4: Admin Interface & Polish

- **Design and implement admin interface** (structure TBD):
  - Admin dashboard/landing page
  - Manage areas page
  - Manage pubs page (add/edit forms)
  - Manage users page
- Security review
- Performance optimization
- Deploy to chosen hosting platform
- User acceptance testing

### Phase 5: Future Enhancements (Optional)

- Pub image upload and display
- Export visit history
- Statistics/charts
- Pub ratings/favorites
- Progressive Web App (PWA) for offline support

## Future Enhancements

- Export visit history
- Charts and statistics
- Pub ratings/favorites
- Progressive Web App (PWA)
- Push notifications for new pubs

---

**End of Specification**
