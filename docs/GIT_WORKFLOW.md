# Git and GitHub Workflow

## Recommended branch

Use `main` as the protected/default branch.

## Commit message format

Use short, descriptive Conventional Commit-style messages:

- `feat: add project status filtering`
- `fix: resolve task status initialization`
- `docs: improve deployment instructions`
- `refactor: simplify project service mapping`
- `test: add task service tests`
- `style: format task list template`
- `perf: reduce dashboard API requests`
- `build: update frontend build configuration`
- `ci: add GitHub Actions build checks`
- `chore: update development tooling`
- `revert: revert task filtering change`

Keep the first line concise. If a change needs explanation, add a blank line and a short body.

## Basic update cycle

```bash
git status
git add .
git commit -m "feat: describe the change"
git push origin main
```

## Before pushing

```bash
git status
git diff --cached
git ls-files | findstr /I "appsettings .env secrets .pfx .p12"
```

Never commit passwords, API keys, private certificates, production connection strings, or other secrets.
