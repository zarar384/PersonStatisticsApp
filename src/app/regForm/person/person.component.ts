import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Person } from 'src/app/model/person.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {
  isAdvance: boolean = false;
  otherCheck: string = "Other";
  person: Person = new Person();

  constructor(private apiHit: ApiService){}

  ngOnInit(){
    // this.apiHit.getData().subscribe((response:any) => {
    //   this.person = response;
    //   console.log(this.person);
    // })
  }
  integreRegex = /^\d+$/

  emailRegex = /(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/

  registerForm = new FormGroup({
    name : new FormControl("", [Validators.required, Validators.maxLength(32)]),
    phone : new FormControl("", [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern(this.integreRegex)]),
    email : new FormControl("", [Validators.required, Validators.maxLength(32), Validators.pattern(this.emailRegex)]),
    sex : new FormControl("", [Validators.required, Validators.maxLength(32)]),
  })

  registerFn(){
    console.log(this.registerForm.value)
    this.person.name = this.registerForm.value.name as string;
    this.person.phone = this.registerForm.value.phone as unknown as number;
    this.person.mail = this.registerForm.value.email as string;
    this.person.sex = this.registerForm.value.sex as string;
    
    this.apiHit.postData(this.person).subscribe((response:any) => {
      console.log("Data inserted successfully");
      this.ngOnInit();
    })

  }

  withAdvance(value: boolean){
    this.isAdvance = this.isAdvance == false? true : false;
  }

  clickOtherRadio(event: MouseEvent){
    if(event){      
      this.otherCheck = "Eblan";
    }
  }

  clickCorrectRadio(event: MouseEvent){
    if(event){
      if(this.otherCheck==="Eblan"){
        this.otherCheck = "Other";
      }
    }
  }
}
