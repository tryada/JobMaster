import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { Skill } from '../../shared/models/skill.model';
import { SkillService } from '../../shared/services/skill.service';

@Component({
  selector: 'app-skill-list',
  standalone: true,
  imports: [NgFor, NgIf, FormsModule],
  templateUrl: './skill-list.component.html'
})
export class SkillListComponent {

  @Input({required: true}) skills: Skill[];
  @Output() skillDeleted = new EventEmitter<Skill>();

  editedSkill: Skill;
  editedSkillName: string;

  constructor(private skillService: SkillService) { }

  onEdit(skill: Skill): void {
    this.editedSkill = skill;
    this.editedSkillName = skill.name;
  }

  onCancel(): void {
    this.editedSkill = null;
    this.editedSkillName = null;
  }

  onSave(): void {
    this.editedSkill.name = this.editedSkillName;
    this.skillService.updateSkill(this.editedSkill).subscribe(
      () => {
        this.editedSkill = null;
      }
    );
  }

  onDelete(): void {
    this.skillService.deleteSkill(this.editedSkill).subscribe(
      () => {
        this.skillDeleted.emit(this.editedSkill);
        this.editedSkill = null;
      }
    );
  }
}