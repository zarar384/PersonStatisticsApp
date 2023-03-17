import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-advance',
  templateUrl: './advance.component.html',
  styleUrls: ['./advance.component.css'],
})
export class AdvanceComponent {
  createFamilyBlock(event: any) {
    var family = ['Mother', 'Brother', 'Sister', 'Grandmother', 'Grandfather'];
    const random = Math.floor(Math.random() * family.length);

    const div = document.getElementById('family');
    var inputChild = div?.lastElementChild;
    inputChild?.setAttribute('style', 'margin-bottom: 20px;');

    const input = document.createElement('input');
    input.type = 'text';
    input.className = 'form-control';
    input.setAttribute('style', 'margin-bottom: 20px;');
    input.id = 'family';
    input.placeholder = family[random];

    div?.appendChild(input);
  }
}
