import { Component } from '@angular/core';
import { Person } from 'src/app/model/person.model';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent {
  person: Person | undefined;
  isAdvance: boolean = false;
  
  withAdvance(value: boolean){
    this.isAdvance = this.isAdvance == false? true : false;
  }

}
