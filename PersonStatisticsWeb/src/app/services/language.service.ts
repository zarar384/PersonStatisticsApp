import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { KeyObject } from 'crypto';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  constructor(private translate: TranslateService) {}

  getCurrentLanguage(): string {
    return this.translate.currentLang;
  }

  setDefaultLaguage() {
    this.translate.setDefaultLang('en');
  }

  setLanguage(language: string) {
    if (!this.translate.langs.includes(language)) {
      throw new Error(`Language ${language} does not exists.`);
    }
    this.translate.use(language);
  }

  toText(key: string): string {
    return this.translate?.instant([key]) || '';
  }

  isLanguageSupported(language: string): boolean {
    return this.translate.langs.includes(language);
  }
  setDefaultLanguage(language: string) {
    this.translate.setDefaultLang(language);
  }
}
