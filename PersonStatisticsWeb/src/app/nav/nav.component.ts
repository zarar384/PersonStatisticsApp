import { Component, OnInit, TemplateRef } from '@angular/core';
import { LogInFormComponent } from '../log-in-form/log-in-form.component';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';
import { LanguageService } from '../services/language.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  isLoggedIn: boolean = false;

  constructor(
    private modalService: NgbModal,
    private languageService: LanguageService
  ) {}

  ngOnInit(): void {}

  switchLanguage(language: string) {
    this.languageService.setLanguage(language);
  }

  openLogInForm() {
    const modal: NgbModalRef = this.modalService.open(LogInFormComponent, {
      ariaLabelledBy: 'modal-basic-title',
    });

    modal.result.then(
      (res) => {
        console.log('LogInFormComponent is closed');
      },
      (reason) => {
        console.log('Are you sure you want to close the LogInForm component?');
      }
    );
  }
}
