# PubLog Project Instructions

## IMPORTANT: Read the Specification First

Before starting any work on this project, **you MUST read the complete specifications**:

📄 **Functional Spec:** `/docs/spec.md`

The spec contains:

- Complete functional requirements
- Technology stack decisions (Blazor Server, Azure SQL, Tailwind CSS, EF Migrations)
- Data model and entity relationships
- User roles and permissions (Anonymous, User, Admin)
- Page-by-page UI specifications
- Development phases and priorities

📄 **Style Guide:** `/docs/style.md`

The style guide contains:

- Code style and conventions
- Naming standards
- Best practices for this project

## Key Decisions Already Made

- **Framework**: Blazor Server (.NET 10)
- **Database**: Azure SQL Database with EF Core Migrations + local SQL Server for dev
- **Styling**: Tailwind CSS
- **Maps**: Leaflet.js with OpenStreetMap
- **Auth**: Cookie-based with User/Admin roles
- **Deployment**: Azure App Service with GitHub Actions CI/CD

## Development Approach

1. Read `/docs/spec.md` in full before writing any code
2. Follow the development phases outlined in the spec
3. Use EF Migrations for all database schema changes
4. Implement mobile-first responsive design
5. Seed initial admin account with default password

## Questions?

If anything is unclear, refer back to the spec. It was created through detailed discussions and contains all architectural decisions.
