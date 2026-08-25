# Repository Preparation

This package was prepared from the supplied `ProjectManagementSystem_UI_UPDATED` project.

## Source preservation

The application source code and runtime configuration were kept intact. No application feature was intentionally rewritten as part of the GitHub packaging step.

## Removed from the repository package

Generated/local-only artifacts were removed because Git should not track them:

- Visual Studio `.vs/` cache
- .NET `bin/` and `obj/` output
- `*.csproj.user` per-user Visual Studio settings
- Other generated build/cache folders when present

These files are covered by the root `.gitignore` and are recreated locally when needed.

## Added

- Root `.gitignore`
- `.gitattributes`
- GitHub Actions CI workflow
- Pull request template
- Bug/feature issue templates
- Git/GitHub workflow documentation
- Deployment/hosting documentation
- Repository-level README

## Important

The project still requires a real production API URL and production database configuration for public hosting. Those values are environment/deployment concerns and were not invented or hard-coded into this package.
