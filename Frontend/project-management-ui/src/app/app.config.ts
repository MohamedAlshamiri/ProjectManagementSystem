import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { routes } from './app.routes';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import ar from '@angular/common/locales/ar';
import { en_US, provideNzI18n } from 'ng-zorro-antd/i18n';
import { provideTranslateService } from '@ngx-translate/core';
import { provideTranslateHttpLoader } from '@ngx-translate/http-loader';

registerLocaleData(en);
registerLocaleData(ar);

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    provideHttpClient(),

    // ngx-translate v18: use the official HTTP-loader provider helper.
    // The old manual TRANSLATE_HTTP_LOADER_CONFIG + TranslateHttpLoader
    // combination can leave the application displaying raw translation keys
    // when the loader configuration is not wired correctly.
    provideTranslateService({
      loader: provideTranslateHttpLoader({
        prefix: '/assets/i18n/',
        suffix: '.json',
        failOnError: true
      }),
      fallbackLang: 'en',
      lang: 'en'
    }),

    provideNzI18n(en_US)
  ]
};
