import { ApplicationConfig, inject, provideAppInitializer, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { routes } from './app.routes';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import ar from '@angular/common/locales/ar';
import { en_US, provideNzI18n } from 'ng-zorro-antd/i18n';
import { provideTranslateService, TranslateService } from '@ngx-translate/core';
import { provideTranslateHttpLoader } from '@ngx-translate/http-loader';

registerLocaleData(en);
registerLocaleData(ar);

const initialLanguage = (): 'en' | 'ar' => {
  const saved = localStorage.getItem('pms-language');
  return saved === 'ar' ? 'ar' : 'en';
};

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    provideHttpClient(),

    provideTranslateService({
      loader: provideTranslateHttpLoader({
        prefix: './assets/i18n/',
        suffix: '.json',
        enforceLoading: true
      }),
      fallbackLang: 'en'
    }),

    provideAppInitializer(() => {
      const translate = inject(TranslateService);
      const language = initialLanguage();
      return firstValueFrom(translate.use(language));
    }),

    provideNzI18n(en_US)
  ]
};
