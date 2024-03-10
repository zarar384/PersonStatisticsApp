import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonComponent } from './regForm/person/person.component';
import { TablePersonComponent } from './regForm/table-person/table-person.component';
import { AccountGuard } from './guard/account.guard';

const routes: Routes = [
  { path: 'person', component: PersonComponent },
  { path: 'personTable', component: TablePersonComponent },
  {
    path: 'user',
    pathMatch: 'prefix',
    loadChildren: () => import('./user/user.module').then((m) => m.UserModule),
    canActivate: [AccountGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
