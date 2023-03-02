import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../model/person.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  url = 'http://localhost:3000/';
  person: Person[] = [];

  constructor(private http: HttpClient) {}

  postData(data: Person) {
    return this.http.post(this.url + 'person', data);
  }

  getData() {
    var personJsonList = this.http.get(this.url + 'person');
    // this.person.push(personJsonList);
    return personJsonList;
  }
}
