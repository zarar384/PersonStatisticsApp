import { Component } from '@angular/core';
import { Person } from 'src/app/model/person.model';
import { MatDialog } from '@angular/material/dialog';
import { PersonComponent } from '../person/person.component';
import { MatTableDataSource } from '@angular/material/table';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-table-person',
  templateUrl: './table-person.component.html',
  styleUrls: ['./table-person.component.css'],
})
export class TablePersonComponent {
  persons: Person[] = [];
  dataSource: MatTableDataSource<Person> = new MatTableDataSource<Person>([]);
  displayedColumns: string[] = ['id', 'name', 'mail', 'phone', 'sex', 'delete'];
  constructor(private personService: PersonService, private dilog: MatDialog) {}

  ngOnInit(): void {
    this.loadPersons();
  }

  loadPersons() {
    this.personService.getData().subscribe({
      next: (persons) => (this.dataSource.data = persons.person),
    });
  }

  openDilog() {
    this.dilog
      .open(PersonComponent)
      .afterClosed()
      .subscribe(() => {
        this.loadPersons();
      });
  }

  deletePerson(id: number) {
    this.personService.delData(id).subscribe({
      next: () => {
        this.loadPersons();
      },
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }
}
