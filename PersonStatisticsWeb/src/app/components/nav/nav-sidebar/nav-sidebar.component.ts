import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-sidebar',
  templateUrl: './nav-sidebar.component.html',
  styleUrl: './nav-sidebar.component.css',
})
export class NavSidebarComponent {
  activeBtn: string = '';

  setActive(btnName: string) {
    this.activeBtn = btnName;
  }
}
