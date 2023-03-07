import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../model/person.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  url = 'http://localhost:3000/';
  status: string;
  errorMessage: any;

  constructor(private http: HttpClient) {}

  postData(data: Person) {
    return this.http.post(this.url + 'person', data);
  }

  getData() {
    var personJsonList = this.http.get(this.url + 'person');
    // this.person.push(personJsonList);
    return personJsonList;
  }

  delData(id: number) {
    return this.http.delete(this.url + 'person/' + id);
  }
}
