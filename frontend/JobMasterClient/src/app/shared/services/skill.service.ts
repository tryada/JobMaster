import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, shareReplay } from 'rxjs/operators';

import { Skill } from '../models/skill.model';
import { environment } from '../../../environments/environment';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SkillService {

  private data: Observable<Skill[]>;

  constructor(private httpClient: HttpClient) { }

  getData() {
    if (!this.data) {
      this.refreshData();
    }
    return this.data;
  }

  refreshData() {
    this.data = this.httpClient
      .get<Skill[]>(environment.apiUrl + 'skills')
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