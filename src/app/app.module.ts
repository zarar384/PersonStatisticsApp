import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { PersonComponent } from './regForm/person/person.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AdvanceComponent } from './regForm/advance/advance.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    AdvanceComponent,
  ],
  imports: [
    BrowserModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
