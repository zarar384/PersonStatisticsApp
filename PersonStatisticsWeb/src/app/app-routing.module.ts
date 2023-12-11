import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonComponent } from './regForm/person/person.component';
import { TablePersonComponent } from './regForm/table-person/table-person.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'person', component: PersonComponent },
  { path: 'personTable', component: TablePersonComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
