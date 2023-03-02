import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonComponent } from './regForm/person/person.component';
import { TablePersonComponent } from './regForm/table-person/table-person.component';

const routes: Routes = [
  { path: 'person', component: PersonComponent },
  { path: 'personTable', component: TablePersonComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
