import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  constructor(private translate: TranslateService) {}

  getCurrentLanguage(): string {
    return this.translate.currentLang;
  }

  setLanguage(language: string) {
    this.translate.use(language);
  }

  toText(key: string): string {
    return this.translate.instant(key);
  }
}
