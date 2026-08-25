# Project Management System

A full-stack project management application built with **Angular 21**, **ASP.NET Core 8 Web API**, **Entity Framework Core 8**, and **SQL Server/LocalDB**.

## Repository structure

```text
ProjectManagementSystem/
├── Backend/
│   ├── ProjectManagement.slnx
│   └── ProjectManagement/
│       ├── Controllers/
│       ├── Data/
│       ├── DTOs/
│       ├── Entities/
│       ├── Extensions/
│       ├── Mapping/
│       ├── Middleware/
│       ├── Repositories/
│       ├── Responses/
│       ├── Services/
│       ├── Properties/
│       ├── Program.cs
│       └── ProjectManagement.csproj
├── Frontend/
│   └── project-management-ui/
│       ├── src/
│       ├── public/
│       ├── angular.json
│       ├── package.json
│       └── package-lock.json
├── docs/
├── .github/
├── .gitignore
└── .gitattributes
```

## Main features

- Dashboard with project/task statistics.
- Projects CRUD.
- Tasks CRUD.
- Task search, sorting, filtering and pagination.
- Project/status filtering.
- English and Arabic translations.
- RTL support for Arabic.
- Responsive dashboard, header, sidebar and footer.
- API error/retry states.
- Swagger/OpenAPI for the backend.
- Development database initialization and lookup-data seeding.

## Technology stack

### Backend

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core 8
- SQL Server provider
- AutoMapper
- Swagger / Swashbuckle

### Frontend

- Angular 21
- TypeScript 5.9
- Angular Router
- RxJS 7.8
- NG-ZORRO 21
- ngx-translate 18

## Local requirements

- Visual Studio 2022 with the ASP.NET/.NET workload, or .NET 8 SDK.
- SQL Server LocalDB for the supplied development connection string.
- Node.js compatible with Angular 21. Angular's compatibility table lists Node.js `^20.19.0`, `^22.12.0`, or `^24.0.0` for Angular 21; Node.js 22 LTS is a practical choice for this project.
- npm 11 as declared by the frontend `package.json`.

## Run the backend

1. Open `Backend/ProjectManagement.slnx` in Visual Studio.
2. Set `ProjectManagement` as the startup project.
3. Run the `https` profile.
4. Confirm Swagger opens at:

```text
https://localhost:7116/swagger
```

The development configuration uses LocalDB and creates the database/lookup data on startup when needed.

## Run the frontend

Open a terminal in:

```text
Frontend/project-management-ui
```

Run:

```bash
npm install
npm start
```

Then open:

```text
http://localhost:4200
```

The development API URL is configured in:

```text
src/environments/environment.ts
```

as:

```text
https://localhost:7116/api
```

## Important production/hosting note

Pushing this repository to GitHub stores and versions the source code; GitHub does not run the ASP.NET Core API or SQL Server database for this application. A full public deployment needs separate backend/database hosting and a public API URL for the Angular production build.

See [`docs/DEPLOYMENT.md`](docs/DEPLOYMENT.md) for the deployment model.

## GitHub

Recommended repository name:

```text
project-management-system
```

Suggested description:

```text
Full-stack Project Management System built with Angular 21, ASP.NET Core 8 Web API, Entity Framework Core, and SQL Server.
```

Recommended topics:

```text
angular
angular21
aspnet-core
dotnet8
csharp
typescript
sql-server
entity-framework-core
project-management
ng-zorro
ngx-translate
```

For the exact GitHub upload workflow and commit message conventions, see [`docs/GIT_WORKFLOW.md`](docs/GIT_WORKFLOW.md).

## CI

GitHub Actions is configured in `.github/workflows/ci.yml` to build the .NET backend and Angular frontend on pushes and pull requests targeting `main`.

## Security

The repository intentionally excludes Visual Studio caches, build output, `node_modules`, local environment files, user-specific project files and other generated artifacts. Never commit production credentials or API secrets.

## License

No license is imposed by this repository package. If the repository will be public and you want others to have explicit permission to reuse the code, add the license you choose through GitHub before publishing it as an open-source project.
