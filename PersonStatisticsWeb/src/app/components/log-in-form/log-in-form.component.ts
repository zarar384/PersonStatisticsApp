import { Component, OnInit, Optional } from '@angular/core';
import {
  NgbActiveModal,
  NgbModal,
  NgbModalRef,
} from '@ng-bootstrap/ng-bootstrap';
import { SignUpFormComponent } from '../sign-up-form/sign-up-form.component';
import { AccountService } from 'src/app/services/account.service';
import { error } from 'console';

@Component({
  selector: 'app-log-in-form',
  templateUrl: './log-in-form.component.html',
  styleUrls: ['./log-in-form.component.css'],
})
export class LogInFormComponent implements OnInit {
  model: any = {};

  constructor(
    @Optional() private readonly activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private readonly accountService: AccountService
  ) {}

  ngOnInit(): void {}

  closeLogInForm() {
    if (this.activeModal) {
      this.activeModal.close();
    }
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: (response) => {
        if (this.activeModal) {
          this.closeLogInForm();
          this.model = {};
        }
      },
    });
  }

  openSignUpForm() {
    this.closeLogInForm();
    const modal: NgbModalRef = this.modalService.open(SignUpFormComponent);

    //modal.result..
  }
}
