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

  constructor(private http: HttpClient, private toastService: ToastService) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user as User) {
          this.toastService.addAlert(
            ToastType.Success,
            `Hello ${user.username}!`,
            true
          );
        }
      }),
      catchError((error) => {
        if (Array.isArray(error.error)) {
          error.error.forEach((err) => {
            this.toastService.addAlert(ToastType.Error, err.description, true);
          });
        }
        this.toastService.addAlert(ToastType.Error, error.message, true);
        return throwError(error);
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((resp: any) => {
        if (Array.isArray(resp)) {
          resp.forEach((error) => {
            this.toastService.addAlert(
              ToastType.Error,
              error.description,
              true
            );
          });
        } else if (resp as User) {
          this.toastService.addAlert(
            ToastType.Success,
            `Accoun ${resp.username} has been created!`,
            true
          );
        }
      }),
      catchError((error) => {
        if (Array.isArray(error.error)) {
          error.error.forEach((err) => {
            this.toastService.addAlert(ToastType.Error, err.description, true);
          });
        }
        this.toastService.addAlert(ToastType.Error, error.message, true);
        return throwError(error);
      })
    );
  }
}
