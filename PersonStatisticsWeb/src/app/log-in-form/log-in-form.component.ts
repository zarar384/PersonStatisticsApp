import { Component, OnInit, Optional } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-log-in-form',
  templateUrl: './log-in-form.component.html',
  styleUrls: ['./log-in-form.component.css'],
})
export class LogInFormComponent implements OnInit {
  constructor(@Optional() private readonly activeModal: NgbActiveModal) {}

  ngOnInit(): void {}

  closeLogInForm() {
    if (this.activeModal) {
      this.activeModal.close();
    }
  }
}
