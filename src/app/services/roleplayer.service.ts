import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Roleplayer } from '../model/roleplayer.model';

@Injectable({
  providedIn: 'root',
})
export class RoleplayerService {
  url = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getRoleplayers() {
    this.http.get(this.url + 'roleplayer');
  }

  getRoleplayer(id: number) {
    this.http.get(this.url + 'roleplayer/' + id);
  }

  delRoleplayer(id: number) {
    this.http.delete(this.url + 'roleplayer/' + id);
  }

  postRoleplayer(roleplayer: Roleplayer) {
    this.http.post(this.url + 'roleplayer', roleplayer);
  }
}
