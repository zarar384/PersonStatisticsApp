import { Component } from '@angular/core';
import { Person } from 'src/app/model/person.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-table-person',
  templateUrl: './table-person.component.html',
  styleUrls: ['./table-person.component.css'],
})
export class TablePersonComponent {
  persons: Person[] = [];

  constructor(private apiHit: ApiService) {}

  ngOnInit(): void {
    this.loadPersons();
  }

  loadPersons() {
    this.apiHit.getData().subscribe((response: any) => {
      this.persons = response;
      console.log(this.persons);
    });
  }
}
