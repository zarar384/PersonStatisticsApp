import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Race } from '../model/race.Model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class RaceService {
  races: Race[];
  url = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getRaces() {
    this.http.get<Race[]>(this.url + 'race').subscribe({
      next: (race: Race[]) => this.races + 'race',
      error: (err: Error) =>
        console.error(
          '{\\__/}\n ( •.•)\n / >You have no connection to the API'
        ),
    });
  }

  getRace(id: number) {
    return this.http.get(this.url + 'race/' + id);
  }

  getRandomStats(id: number) {
    var race = this.getRace(id) as unknown as Race;
    var min = 1;
    var max = 50;
    var random = Math.floor(Math.random() * (max - min) + min);

    var newStats = {
      id: race.id,
      name: race.name,
      describe: race.strength,
      strength: random,
      dexterity: random,
      intelligence: random,
    };

    return newStats;
  }
}
