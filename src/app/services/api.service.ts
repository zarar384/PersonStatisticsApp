import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../model/person.model';


@Injectable({
  providedIn: 'root',
})
export class ApiService {
  url = 'http://localhost:3000/';
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

  loadXML() {
    return this.http.get('assets/language-ru.xml', {
      headers: new HttpHeaders()
        .set('Content-Type', 'text/xml')
        .append('Access-Control-Allow-Methods', 'GET')
        .append('Access-Control-Allow-Origin', '*')
        .append(
          'Access-Control-Allow-Headers',
          'Access-Control-Allow-Headers, Access-Control-Allow-Origin, Access-Control-Request-Method'
        ),
      responseType: 'text',
    });
  }

  
}
