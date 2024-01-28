import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { catchError, map, tap } from 'rxjs/operators';
import { User } from '../model/user';
import { throwError } from 'rxjs';
import { ToastService } from './toast.service';
import { ToastType } from 'src/enum/toastType';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private ToastService: ToastService) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((resp: any) => {
        console.log('bib');
        if (Array.isArray(resp)) {
          resp.forEach((error) => {
            console.log(error);
            this.ToastService.addAlert(
              ToastType.Error,
              error.description,
              true
            );
          });
        } else if (resp as User) {
          console.log(resp);
        }
      }),
      catchError((error) => {
        if (Array.isArray(error.error)) {
          error.error.forEach((err) => {
            console.log(err);
            this.ToastService.addAlert(ToastType.Error, err.description, true);
          });
        }

        this.ToastService.addAlert(ToastType.Error, error.message, true);
        return throwError(error);
      })
    );
  }
}
