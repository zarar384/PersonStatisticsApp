import { Component, OnInit, TemplateRef } from '@angular/core';
import { LogInFormComponent } from '../../log-in-form/log-in-form.component';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { LanguageService } from 'src/app/services/language.service';
import { AccountService } from 'src/app/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  isCollapsed: boolean = true;

  constructor(
    private modalService: NgbModal,
    private languageService: LanguageService,
    public accountService: AccountService,
    private router: Router
  ) {
    languageService.setDefaultLaguage();
  }

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

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  toggleSidebar(): void {
    this.isCollapsed = !this.isCollapsed;
  }
}
