import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Skill } from '../../shared/models/skill.model';
import { SkillService } from '../../shared/services/skill.service';

@Component({
  selector: 'app-new-skill',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './new-skill.component.html'
})
export class NewSkillComponent {

  @Output() skillAdded = new EventEmitter<Skill>();

  constructor(private skillService: SkillService) { }

  skillName: string = '';

  onAdd(): void {

    if (!this.skillName) {
      return;
    }

    this.skillService.addSkill(this.skillName).subscribe(
      (skill: Skill) => {
        this.skillName = '';
        this.skillAdded.emit(skill);
      }
    );
  }
}
