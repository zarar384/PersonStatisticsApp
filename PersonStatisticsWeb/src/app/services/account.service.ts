import { HttpClient } from '@angular/common/http';
import { HtmlParser } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Account } from '../model/account';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: Account) => {
        const user = response;
        if (user) {
        }
      })
    );
  }

  register(model: any) {
    console.log(this.baseUrl);
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((user: Account) => {
        if (user) {
          console.log(user);
        }
      })
    );
  }
}
