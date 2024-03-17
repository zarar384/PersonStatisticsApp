import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { User } from '../model/user';
import { Observable, ReplaySubject, of, throwError } from 'rxjs';
import { ToastService } from './toast.service';
import { ToastType } from 'src/enum/toastType';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private toastService: ToastService) {
    const auth = this.getAuth();
    if (auth && auth.token) {
      this.currentUserSource.next(auth);
    }
  }

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user as User) {
          this.setCurrentUser(user);
          this.toastService.addAlert(
            ToastType.Success,
            `Hello ${user.username}!`,
            true
          );
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((resp: any) => {
        if (resp as User) {
          this.setCurrentUser(resp);
          this.toastService.addAlert(
            ToastType.Success,
            `Accoun ${resp.username} has been created!`,
            true
          );
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('register');
    this.currentUserSource.next(null);
  }

  loggedIn(): Observable<boolean> {
    return this.currentUser$.pipe(map((user) => !!user));
  }

  getAuth(): User | null {
    const lSItm = localStorage.getItem('register');
    const auth = JSON.parse(lSItm);
    return auth ? auth : null;
  }

  setCurrentUser(user: User) {
    if (!user) return;
    user.roles = [];
    const roles = this.getDecotedToken(user.token).role;
    Array.isArray(roles) ? user.roles == roles : user.roles.push(roles);
    localStorage.setItem('register', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  getDecotedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }
}
