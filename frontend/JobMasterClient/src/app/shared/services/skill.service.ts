import { Injectable } from '@angular/core';
import { catchError, map, shareReplay } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

import { Skill } from '../models/skill.model';
import { UserHttpClient } from '../../global/services/user-http-client.service';

@Injectable({
  providedIn: 'root',
})
export class SkillService {

  private data: Observable<Skill[]>;

  constructor(private httpClient: UserHttpClient) { }

  getData() {
    if (!this.data) {
      this.refreshData();
    }
    return this.data;
  }

  refreshData() {
    this.data = this.httpClient
      .get<Skill[]>('skills')
      .pipe(
        shareReplay(),
        map((skills: Skill[]) => {
          return skills.map(skill => {
            return new Skill(skill.id, skill.name);
          });
        }),
        catchError(() => of([]))
      );
  }
}