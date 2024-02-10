import { Component, OnInit, Optional } from '@angular/core';
import {
  NgbActiveModal,
  NgbModal,
  NgbModalRef,
} from '@ng-bootstrap/ng-bootstrap';
import { LogInFormComponent } from '../log-in-form/log-in-form.component';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { AccountService } from 'src/app/services/account.service';
import { ToastService } from 'src/app/services/toast.service';
import { ToastType } from 'src/enum/toastType';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.css'],
})
export class SignUpFormComponent implements OnInit {
  signUpForm: FormGroup = new FormGroup({});
  validationError: string[] | undefined;

  constructor(
    @Optional() private readonly activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private fb: FormBuilder,
    private accountService: AccountService,
    private ToastService: ToastService
  ) {}
  ngOnInit(): void {
    this.inicializeForm();
  }

  inicializeForm() {
    this.signUpForm = this.fb.group({
      username: ['', Validators.required],
      // nickname: ['', Validators.required],
      // dateOfBirth: ['', Validators.required],
      password: [
        '',
        [Validators.required, Validators.minLength(5), Validators.maxLength(8)],
      ],
      confirmPassword: [
        '',
        [Validators.required, this.matchValues('password')],
      ],
    });
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      const currentControlValue = control.value;
      const parentControlValue = control.parent?.get(matchTo)?.value;

      return currentControlValue === parentControlValue
        ? null
        : { notMathing: true };
    };
  }

  close() {
    if (this.activeModal) {
      this.activeModal.close();
    }
  }

  register() {
    const value = this.signUpForm.value;
    this.accountService.register(value).subscribe(
      (resp: any) => {
        if (this.activeModal) {
          this.activeModal.close();
        }
      },
      (err) => {
        this.validationError == err;
      }
    );
  }

  openLogInForm() {
    this.close();

    const modal: NgbModalRef = this.modalService.open(LogInFormComponent);

    //modal.result..
  }
}
