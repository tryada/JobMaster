import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';

import { Skill } from '../models/skill.model';
import { UserHttpClient } from '../../global/services/user-http-client.service';

@Injectable({
  providedIn: 'root',
})
export class SkillService {

  constructor(private httpClient: UserHttpClient) { }

  getData() {
    return this.httpClient
    .get<Skill[]>('skills')
    .pipe(
      map((skills: Skill[]) => {
        return skills.map(skill => {
          return new Skill(skill.id, skill.name);
        });
      }),
      catchError(() => of([]))
    );
  }

  addSkill(skillName: string) {
    return this.httpClient.post<Skill>('skills', { name: skillName })
      .pipe(
        map((skill: Skill) => {
          return new Skill(skill.id, skill.name);
        })
      );
  }

  updateSkill(skill: Skill) {
    return this.httpClient.put<Skill>('skills/' + skill.id, { name: skill.name });
  }

  deleteSkill(skill: Skill) {
    return this.httpClient.delete('skills/' + skill.id);
  }
}