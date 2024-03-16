import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { ToastService } from './toast.service';
import { LanguageService } from './language.service';
import { ToastType } from 'src/enum/toastType';

@Injectable({
  providedIn: 'root',
})
export class GlobalErrorHandlerService implements ErrorHandler {
  constructor(
    private toastService: ToastService,
    private languageService: LanguageService
  ) {}

  handleError(error: any): void {
    let message = this.languageService.toText('');
    if (Array.isArray(error)) {
      error.map((err) =>
        this.toastService.addAlert(ToastType.Error, err.error, true)
      );
    } else {
      this.toastService.addAlert(ToastType.Error, error.error, true);
    }
  }
}
