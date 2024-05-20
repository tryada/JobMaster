import { Pipe, PipeTransform } from '@angular/core';
import { Skill } from '../../shared/models/skill.model';

@Pipe({
  name: 'skillName',
  standalone: true
})
export class SkillNamePipe implements PipeTransform {

  transform(value: string, skills: Skill[]): string {
    const skill = skills.find(s => s.id === value);
    return skill ? skill.name : '';
  }
}