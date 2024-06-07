import { Component, OnInit } from '@angular/core';

import { SkillListComponent } from './skill-list/skill-list.component';
import { NewSkillComponent } from './new-skill/new-skill.component';
import { Skill } from '../shared/models/skill.model';
import { SkillService } from '../shared/services/skill.service';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [SkillListComponent, NewSkillComponent],
  templateUrl: './skills.component.html'
})
export class SkillsComponent implements OnInit {

  skills: Skill[];

  constructor(private skillService: SkillService ) { }

  ngOnInit(): void {
    this.skillService.getData().subscribe(
      skills => this.skills = skills
    );
  }

  onSkillAdded(skill: Skill): void {
    this.skills.push(skill);
  }

  onSkillDeleted(skill: Skill): void {
    this.skills = this.skills.filter(s => s !== skill);
  }
}
