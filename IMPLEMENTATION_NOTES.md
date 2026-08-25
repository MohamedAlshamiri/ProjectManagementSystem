# ProjectManagementSystem - UI fixes applied

This package contains the requested fixes based on the supplied screenshots/videos.

## Applied changes

1. Fixed ngx-translate v18 configuration by using the official `provideTranslateHttpLoader()` provider.
   - Translation files are loaded from `/assets/i18n/en.json` and `/assets/i18n/ar.json`.
   - `failOnError: true` is enabled so a missing translation file cannot silently leave raw keys such as `DASHBOARD.WELCOME` on screen.
2. Added runtime NG-ZORRO locale switching between English and Arabic.
3. Registered Angular English and Arabic locale data.
4. Kept document direction synchronized with the selected language (`ltr` / `rtl`).
5. Changed the responsive sidebar breakpoint from `lg` to `sm` so the desktop layout does not unexpectedly collapse into the zero-width sidebar seen in the supplied screenshots when the browser has a reduced CSS viewport/zoom.
6. Prevented the main application shell from creating a page-level horizontal scrollbar while preserving table-level horizontal scrolling.
7. Made Projects and Tasks page containers shrink correctly inside the responsive layout.

## Verification performed on the source

- All translation keys referenced by the HTML templates were checked against both `en.json` and `ar.json`.
- Result: 93 template translation keys checked; 0 missing in English; 0 missing in Arabic.

## Environment limitation

The supplied environment does not have the .NET SDK installed, and the npm registry/cache available in this execution environment is incomplete, so a full `dotnet build` / Angular production build could not be executed here. The source changes were therefore validated statically and the project remains ready to build on the development machine with its normal dependencies installed.
