import { ResolveFn } from '@angular/router';
import { Skill } from '../models/skill.model';
import { SkillService } from '../services/skill.service';
import { inject } from '@angular/core';

export const skillsResolver: ResolveFn<Skill[]> = (route, state) => {
  
  const skillsService = inject(SkillService);
  return skillsService.getData();
};
