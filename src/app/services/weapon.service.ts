import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Weapon } from '../model/weapon.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class WeaponService {
  url = environment.apiUrl;
  weapons: Weapon[];

  constructor(private http: HttpClient) {}

  getWeapons() {
    this.http.get<Weapon[]>(this.url + 'weapon').subscribe({
      next: (weapon: Weapon[]) => (this.weapons = weapon),
      error: (err: Error) =>
        console.error(
          '{\\__/}\n ( •.•)\n / >You have no connection to the API'
        ),
    });
    return this.weapons;
  }

  getWeapon(id: number) {
    return this.http.get(this.url + 'weapon/' + id);
  }

  postData(data: Weapon) {
    return this.http.post(this.url + 'weapon', data);
  }

  setRandomDanage(id: number) {
    var weapon = this.getWeapon(id) as unknown as Weapon;
    var min = 1;
    var max = 50;
    var randomDamage = Math.floor(Math.random() * (max - min) + min);

    var newWeapon = {
      id: weapon.id,
      name: weapon.name,
      description: weapon.description,
      damage: randomDamage,
      race_id: weapon.race_id,
    };

    return newWeapon;
  }
}
