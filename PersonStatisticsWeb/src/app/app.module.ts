import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { PersonComponent } from './regForm/person/person.component';
import {
  NgbAccordionButton,
  NgbCollapseModule,
  NgbModule,
} from '@ng-bootstrap/ng-bootstrap';
import { AdvanceComponent } from './regForm/advance/advance.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { TablePersonComponent } from './regForm/table-person/table-person.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { TextfieldChangedDirective } from './shared/textfield-changed.directive';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { SignUpFormComponent } from './components/sign-up-form/sign-up-form.component';
import { LogInFormComponent } from './components/log-in-form/log-in-form.component';
import { NavBarComponent } from './components/nav/nav-bar/nav-bar.component';
import { NavSidebarComponent } from './components/nav/nav-sidebar/nav-sidebar.component';

export function httpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    AdvanceComponent,
    NavBarComponent,
    TablePersonComponent,
    TextfieldChangedDirective,
    TextInputComponent,
    LogInFormComponent,
    SignUpFormComponent,
    NavSidebarComponent,
  ],
  imports: [
    BrowserModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatTableModule,
    FontAwesomeModule,
    BsDropdownModule.forRoot(),
    NgbCollapseModule,
    NgbAccordionButton,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: httpLoaderFactory,
        deps: [HttpClient],
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
