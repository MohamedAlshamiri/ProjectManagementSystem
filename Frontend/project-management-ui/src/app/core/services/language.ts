import { Injectable, signal } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { NzI18nService, ar_EG, en_US } from 'ng-zorro-antd/i18n';

export type Language = 'en' | 'ar';

@Injectable({ providedIn: 'root' })
export class LanguageService {
  private readonly currentLanguage = signal<Language>((localStorage.getItem('pms-language') as Language) || 'en');

  constructor(
    private readonly translate: TranslateService,
    private readonly nzI18n: NzI18nService
  ) {
    this.translate.addLangs(['en', 'ar']);
    this.translate.setFallbackLang('en');
    this.translate.use(this.currentLanguage());
    this.applyDirection(this.currentLanguage());
    this.applyNzLocale(this.currentLanguage());
  }

  get language(): Language { return this.currentLanguage(); }

  changeLanguage(language: Language): void {
    this.currentLanguage.set(language);
    localStorage.setItem('pms-language', language);
    this.translate.use(language);
    this.applyDirection(language);
    this.applyNzLocale(language);
  }

  private applyNzLocale(language: Language): void {
    this.nzI18n.setLocale(language === 'ar' ? ar_EG : en_US);
  }

  private applyDirection(language: Language): void {
    document.documentElement.dir = language === 'ar' ? 'rtl' : 'ltr';
    document.documentElement.lang = language;
  }
}
