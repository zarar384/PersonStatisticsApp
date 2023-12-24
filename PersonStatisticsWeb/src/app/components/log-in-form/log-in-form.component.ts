import { Component, OnInit, Optional } from '@angular/core';
import {
  NgbActiveModal,
  NgbModal,
  NgbModalRef,
} from '@ng-bootstrap/ng-bootstrap';
import { SignUpFormComponent } from '../sign-up-form/sign-up-form.component';

@Component({
  selector: 'app-log-in-form',
  templateUrl: './log-in-form.component.html',
  styleUrls: ['./log-in-form.component.css'],
})
export class LogInFormComponent implements OnInit {
  constructor(
    @Optional() private readonly activeModal: NgbActiveModal,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {}

  closeLogInForm() {
    if (this.activeModal) {
      this.activeModal.close();
    }
  }

  openSignUpForm() {
    this.closeLogInForm();
    const modal: NgbModalRef = this.modalService.open(SignUpFormComponent);

    //modal.result..
  }
}
