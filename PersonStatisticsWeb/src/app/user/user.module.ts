import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserEditComponent } from './user-edit/user-edit.component';
import { UserListComponent } from './user-list/user-list.component';

@NgModule({
  declarations: [UserDetailComponent, UserEditComponent, UserListComponent],
  imports: [CommonModule, UserRoutingModule],
})
export class UserModule {}
