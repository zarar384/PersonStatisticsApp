import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../model/person.model';

@Injectable({

  providedIn: 'root'

})

export class ApiService {

  url = 'http://localhost:3000/'

  constructor(private http:HttpClient) { }

  postData(data: Person){
    return this.http.post(this.url + 'person', data)
  }

  getData(){
    return this.http.get(this.url + 'person')
  }

}