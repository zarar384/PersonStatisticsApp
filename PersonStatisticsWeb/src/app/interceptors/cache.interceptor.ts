import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/internal/operators/tap';

//cashes GET requests to reduce the number of requests to the server
@Injectable()
export class CacheInterceptor implements HttpInterceptor {
  private cashe = new Map<string, any>();

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (req.method !== 'GET') {
      return next.handle(req);
    }

    const cachedResponse = this.cashe.get(req.urlWithParams);

    if (cachedResponse) {
      return of(cachedResponse);
    }

    //execute request and cashe response
    return next.handle(req).pipe(
      tap((event) => {
        if (event instanceof HttpResponse) {
          this.cashe.set(req.urlWithParams, event);
        }
      })
    );
  }
}
