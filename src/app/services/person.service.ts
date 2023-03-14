import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../model/person.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  url = environment.apiUrl;
  status: string;
  errorMessage: any;
  textField: string;

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
