import { HttpClient } from '@angular/common/http';
import { HtmlParser } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Person } from '../model/person.model';
import { map } from 'rxjs/operators';
import { User } from 'src/models/user.interface';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response) => {
        const user = response as User;
        if (user) {
          // settCurrentUser
        }
      })
    );
  }
}
