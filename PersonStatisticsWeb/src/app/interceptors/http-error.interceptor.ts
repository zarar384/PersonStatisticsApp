import {
  HttpContextToken,
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { GlobalErrorHandlerService } from '../services/global-error-handler.service';
import { catchError } from 'rxjs/operators';

//context: new HttpContext().Set(DISABLE_INTERCEPTOR, true) 
export const DISABLE_INTERCEPTOR = new HttpContextToken<boolean>(() => false);
@Injectable({
  providedIn: 'root',
})
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(private errorHandler: GlobalErrorHandlerService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (req.context.get(DISABLE_INTERCEPTOR) === true) {
      return next.handle(req);
    }

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        this.errorHandler.handleError(error);
        return throwError(error);
      })
    );
  }
}
