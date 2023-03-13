import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Person } from 'src/app/model/person.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css'],
})
export class PersonComponent implements OnInit {
  isAdvance: boolean = false;
  otherCheck: string = 'Other';
  person: Person = new Person();

  constructor(private apiHit: ApiService) {
    this.form;
  }

  ngOnInit() {
    // this.apiHit.getData().subscribe((response:any) => {
    //   this.person = response;
    //   console.log(this.person);
    // })
  }
  integreRegex = /^\d+$/;

  emailRegex =
    /(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/;

  form = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(32)]),
    phone: new FormControl('', [
      Validators.required,
      Validators.minLength(5),
      Validators.maxLength(15),
      Validators.pattern(this.integreRegex),
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.maxLength(32),
      Validators.pattern(this.emailRegex),
    ]),
    sex: new FormControl('', [
      Validators.required,
      Validators.maxLength(32),
      this.clickOtherRadio,
    ]),
  });

  registerFn() {
    if (this.form.status !== 'INVALID') {
      console.log(this.form.value);

      this.person.name = this.form.value.name as string;
      this.person.phone = this.form.value.phone as unknown as number;
      this.person.mail = this.form.value.email as string;
      this.person.sex = this.form.value.sex as string;
      this.person.dr = new Date().toLocaleString() as unknown as Date;

      this.apiHit.postData(this.person).subscribe((response: any) => {
        console.log('Data inserted successfully');
        this.ngOnInit();
      });
    }
  }

  getControl(name: any): AbstractControl | null {
    return this.form.get(name);
  }

  withAdvance(value: boolean) {
    this.isAdvance = this.isAdvance == false ? true : false;
  }

  clickOtherRadio(control: FormControl) {
    if (control.value == 'eblan') {
      return {
        otherSelected: true,
      };
    }
    return null;
  }

  clickCorrectRadio(event: MouseEvent) {
    const getOtherErr = this.form.get('sex')?.errors?.['otherSelected'];
    if (getOtherErr === true || getOtherErr === undefined) {
      this.otherCheck = 'Eblan';
    } else {
      this.otherCheck = 'Other';
    }
  }
}
