import { Component } from '@angular/core';
import { Person } from 'src/app/model/person.model';
import { ApiService } from 'src/app/services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { PersonComponent } from '../person/person.component';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-table-person',
  templateUrl: './table-person.component.html',
  styleUrls: ['./table-person.component.css'],
})
export class TablePersonComponent {
  persons: Person[] = [];
  dataSource: MatTableDataSource<Person> = new MatTableDataSource<Person>([]);
  displayedColumns: string[] = ['id', 'name', 'mail', 'phone', 'sex'];
  constructor(private apiHit: ApiService, private dilog: MatDialog) {}

  ngOnInit(): void {
    this.loadPersons();
  }

  loadPersons() {
    this.apiHit.getData().subscribe((response: any) => {
      this.dataSource.data = response;
      console.log(this.persons);
    });
  }

  openDilog() {
    this.dilog.open(PersonComponent);
  }
}
