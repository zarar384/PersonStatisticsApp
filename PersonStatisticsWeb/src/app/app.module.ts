import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { PersonComponent } from './regForm/person/person.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AdvanceComponent } from './regForm/advance/advance.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { AppRoutingModule } from './app-routing.module';
import { TablePersonComponent } from './regForm/table-person/table-person.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { TextfieldChangedDirective } from './shared/textfield-changed.directive';
import { WeaponComponent } from './rolePlayForm/weapon/weapon.component';
import { RaceComponent } from './rolePlayForm/race/race.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    AdvanceComponent,
    NavComponent,
    TablePersonComponent,
    TextfieldChangedDirective,
    WeaponComponent,
    RaceComponent,
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
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}