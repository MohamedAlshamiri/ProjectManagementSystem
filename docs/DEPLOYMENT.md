# Deployment and Hosting Notes

## Important architecture note

GitHub is the source-code repository for this project; it is not, by itself, a host for the ASP.NET Core API and SQL Server database used by this application.

The current project has two runtime parts:

1. **Frontend:** Angular 21 application in `Frontend/project-management-ui`.
2. **Backend:** ASP.NET Core 8 Web API in `Backend/ProjectManagement` with SQL Server/LocalDB.

For a real public deployment, the API and database must be hosted on a service that supports ASP.NET Core and SQL Server (or a compatible database setup), while the Angular frontend can be deployed to a static hosting service.

## Local development

1. Start the backend from Visual Studio using the `https` profile.
2. Confirm Swagger opens at `https://localhost:7116/swagger`.
3. Start Angular from `Frontend/project-management-ui` with `npm install` and `ng serve`.
4. Open `http://localhost:4200`.

## Production API URL

The development frontend currently points to:

`https://localhost:7116/api`

The production environment file currently leaves `apiUrl` empty because the real public API URL is not known in this repository package. After deploying the backend, set the production API URL to the public API endpoint before building the frontend for production.

Do not commit passwords, database credentials, API keys, certificates, or other secrets. Use the hosting provider's environment/secret configuration instead.

## GitHub Pages limitation

GitHub Pages can host the generated Angular static files, but it cannot run the ASP.NET Core API or SQL Server database. A full production deployment therefore requires separate backend/database hosting.
