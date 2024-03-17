import {
  HttpContextToken,
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { GlobalErrorHandlerService } from '../services/global-error-handler.service';
import { catchError } from 'rxjs/operators';
import { ErrorCode } from 'src/enum/errorCode';

//context: new HttpContext().Set(DISABLE_INTERCEPTOR, true)
export const DISABLE_INTERCEPTOR = new HttpContextToken<boolean>(() => false);
@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(private errorHandler: GlobalErrorHandlerService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (req.context.get(DISABLE_INTERCEPTOR) === true) {
      return next.handle(req);
    }

    return next.handle(req).pipe(catchError((err) => this.handleError(err)));
  }

  private handleError(error: HttpErrorResponse): Observable<any> {
    const ignoredErrorCodes = [
      ErrorCode.Unauthorized,
      ErrorCode.Forbidden,
      ErrorCode.NotFound,
      ErrorCode.BadRequest,
      ErrorCode.InternalServerError,
      ErrorCode.ServiceUnavailable,
    ];

    this.errorHandler.handleError(error);
    if (ignoredErrorCodes.includes(error.status)) return of(error.message);
    return throwError(error);
  }
}
