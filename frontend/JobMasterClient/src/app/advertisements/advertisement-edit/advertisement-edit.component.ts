import { NgFor, NgIf, formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Advertisement } from '../model/advertisement.model';
import { AdvertisementService } from '../services/advertisement.service';
import { Skill } from '../../shared/models/skill.model';
import { AdvertisementErrorComponent } from '../advertisement-error/advertisement-error.component';

@Component({
  selector: 'app-advertisement-edit',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, NgIf, NgFor, AdvertisementErrorComponent],
  templateUrl: './advertisement-edit.component.html',
  styleUrl: './advertisement-edit.component.css'
})
export class AdvertisementEditComponent implements OnInit {

  advertisementForm: FormGroup;

  editMode = false;
  editModel: Advertisement;
  skills: Skill[];
  invalidData: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private advertisementService: AdvertisementService) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.editModel = data['advertisement'];
      this.editMode = this.editModel != null;
      this.skills = data['skills'];

      if (this.editMode)
        this.invalidData =
          !this.editModel ||
          (this.skills.length === 0 && this.editModel.skills.length > 0);
      else
        this.invalidData = false;

      this.initForm();
    });
  }

  private initForm() {
    const data = this.getFormData();
    this.advertisementForm = new FormGroup({
      'title': new FormControl(data.title, Validators.required),
      'companyName': new FormControl(data.companyName, Validators.required),
      'description': new FormControl(data.description),
      'skills': new FormArray(data.skills),
      'url': new FormControl(data.url, Validators.required),
      'applied': new FormControl(data.applied),
      'appliedDate': new FormControl(data.appliedDate),
      'rejected': new FormControl(data.rejected),
      'replied': new FormControl(data.replied),
      'replyDate': new FormControl(data.replyDate)
    });
  }

  getFormData() {
    if (this.editModel) {
      return {
        'title': this.editModel.title,
        'companyName': this.editModel.companyName,
        'description': this.editModel.description,
        'skills': this.editModel.skills.map(
          (skill) => {
            return this.createSkillFormGroup(skill);
          }
        ),
        'url': this.editModel.url,
        'applied': this.editModel.applied,
        'appliedDate': this.editModel.appliedDate ? formatDate(this.editModel.appliedDate, 'yyyy-MM-dd', 'en-US') : '',
        'rejected': this.editModel.rejected,
        'replied': this.editModel.replied,
        'replyDate': this.editModel.replyDate ? formatDate(this.editModel.replyDate, 'yyyy-MM-dd', 'en-US') : ''
      }
    } else {
      return {
        'title': '',
        'companyName': '',
        'description': '',
        'skills': [] as any[],
        'url': '',
        'applied': false,
        'appliedDate': '',
        'rejected': false,
        'replied': false,
        'replyDate': ''
      }
    }
  }

  onNewSkill() {
    (<FormArray>this.advertisementForm.get('skills')).push(this.createSkillFormGroup())
  }

  onDeleteSkil(index: number) {
    (<FormArray>this.advertisementForm.get('skills')).removeAt(index);
  }

  createSkillFormGroup(value: string = null,) {
    return new FormControl(value, Validators.required);
  }

  get skillsControls() {
    return <FormControl[]>(<FormArray>this.advertisementForm.get('skills')).controls;
  }

  onSubmit() {

    const advertisementData = new Advertisement(
      this.editModel ? this.editModel.id : null,
      this.advertisementForm.value['title'],
      this.advertisementForm.value['companyName'],
      this.advertisementForm.value['description'],
      this.advertisementForm.value['url'],
      this.getSkills(),
      this.advertisementForm.value['applied'],
      this.advertisementForm.value['appliedDate'] || null,
      this.advertisementForm.value['rejected'],
      this.advertisementForm.value['replied'],
      this.advertisementForm.value['replyDate'] || null
    );

    this.advertisementService.saveAdvertisement(advertisementData);
    this.onBack();
  }

  getSkills() {
    return (<FormArray>this.advertisementForm.get('skills')).controls.map(element => {
      return element.value;;
    })
  }

  onDelete() {
    this.advertisementService.deleteAdvertisement(this.editModel.id);
    this.router.navigate(['advertisements']);
  }

  onBack() {
    if (this.editMode) {
      this.router.navigate(['advertisements', this.editModel.id]);
    } else {
      this.router.navigate(['advertisements']);
    }
  }
}
