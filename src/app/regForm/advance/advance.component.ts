import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-advance',
  templateUrl: './advance.component.html',
  styleUrls: ['./advance.component.css'],
})
export class AdvanceComponent {
  createFamilyBlock() {
    console.log('bib');
    var family = ['Mother', 'Brother', 'Sister', 'Grandmother', 'Grandfather'];
    const random = Math.floor(Math.random() * family.length);

    const ul = document.getElementById('family');

    const li = document.createElement('li');
    const input = document.createElement('input');

    input.type = 'text';
    input.className = 'form-control';
    input.setAttribute('style', 'margin-bottom: 20px;');
    input.id = 'family';
    input.placeholder = family[random];

    ul?.appendChild(li);
    li?.appendChild(input);
  }
}
