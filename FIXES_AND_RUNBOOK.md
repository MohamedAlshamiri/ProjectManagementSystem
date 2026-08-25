# Project Management System — v4 Fixed & UI Enhanced

## What was fixed

### Backend
- Fixed the C# `CS0104` ambiguity for `TaskStatus` in `DatabaseInitializer.cs` by using `ProjectManagement.Entities.TaskStatus` explicitly.
- Kept the local-development CORS policy and added `127.0.0.1:4200` variants for the Angular dev server.
- The CORS error shown in the browser is expected when the API is not actually running; the original backend compile error was preventing the API from starting.

### Angular
- Fixed the `NG8002`/unknown property error for `nzTooltipTitle` by importing `NzTooltipModule` into `TaskList`.
- Applied Angular 21 standalone defaults (removed redundant `standalone: true`).
- Applied `OnPush` change detection consistently.
- Made language state signal-backed so English/Arabic + RTL updates remain reactive with OnPush.
- Made save/loading state updates signal-backed where needed.

### UI/UX
- Added a cleaner Projects header with refresh action and project status summary cards.
- Added refresh actions to Projects and Tasks.
- Added overdue-date visual emphasis for unfinished tasks.
- Added Dashboard retry action for API failures.
- Added Dashboard “View all” links for Projects and Tasks.
- Preserved responsive behavior, Arabic RTL support, translations, empty states, filters, pagination, CRUD dialogs and confirmation actions.

## Correct run order

1. Open `Backend/ProjectManagement/ProjectManagement.csproj` in Visual Studio.
2. Build the backend. The Error List must show **0 Errors**.
3. Run the backend using the **https** profile.
4. Open `https://localhost:7116/swagger` and trust the ASP.NET Core development certificate if the browser asks.
5. In a terminal, go to `Frontend/project-management-ui`.
6. Run `npm install`.
7. Run `ng serve -o`.
8. Open `http://localhost:4200`.
9. Test in this order: Dashboard → Projects → Create Project → Tasks → Create Task → Edit/Delete → Filters/Search/Pagination → Arabic/English.

## Important

The database intentionally starts with no projects and no tasks. Therefore a fresh installation correctly shows zero counters and empty lists until you create data. The lookup tables for project statuses, task statuses and priorities are initialized automatically in Development.

The build of the Angular package was not executed in the provided sandbox because the npm registry package `zod-to-json-schema` was not available in the sandbox's offline cache. The source was statically checked for the known template/import blockers and translation-key consistency.
