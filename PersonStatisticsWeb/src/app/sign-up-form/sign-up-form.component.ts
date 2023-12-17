import { Component, Optional } from '@angular/core';
import {
  NgbActiveModal,
  NgbModal,
  NgbModalRef,
} from '@ng-bootstrap/ng-bootstrap';
import { LogInFormComponent } from '../log-in-form/log-in-form.component';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.css'],
})
export class SignUpFormComponent {
  constructor(
    @Optional() private readonly activeModal: NgbActiveModal,
    private modalService: NgbModal
  ) {}

  closeSignInForm() {
    if (this.activeModal) {
      this.activeModal.close();
    }
  }

  openLogInForm() {
    this.closeSignInForm();

    const modal: NgbModalRef = this.modalService.open(LogInFormComponent);

    //modal.result..
  }
}
