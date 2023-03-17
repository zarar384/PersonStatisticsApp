import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../model/person.model';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { EMPTY } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  url = environment.apiUrl;
  status: string;
  errorMessage: any;
  textField: string;
  persons: Person[];

  constructor(private http: HttpClient) {}

  postData(data: Person) {
    return this.http.post(this.url + 'person', data);
  }

  getData() {
    this.http.get<Person[]>(this.url + 'person').subscribe({
      next: (person: Person[]) => (this.persons = person),
      error: (err: Error) =>
        console.error(
          '{\\__/}\n ( •.•)\n / >You have no connection to the API'
        ),
    });
    return this.persons;
  }

  delData(id: number) {
    return this.http.delete(this.url + 'person/' + id);
  }
}
