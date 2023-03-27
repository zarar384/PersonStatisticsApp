import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class XmlService {
  constructor(private http: HttpClient) {}

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
