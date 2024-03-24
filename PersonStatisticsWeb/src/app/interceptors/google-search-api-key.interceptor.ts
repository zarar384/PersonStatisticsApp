import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.dev';

//adds API key, cxID to each HTTP request
@Injectable()
export class GoogleSearchApiKeyInterceptor implements HttpInterceptor {
  private apiKey = environment.googleSearchApiKey;
  private cxID = environment.googleSearchCxID;

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (req.headers.has('google-search-img')) {
      const apiReq = req.clone({
        setParams: {
          key: this.apiKey,
          cx: this.cxID,
        },
      });

      return next.handle(apiReq);
    }

    return next.handle(req);
  }
}
