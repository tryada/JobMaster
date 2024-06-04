import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe, NgFor, NgIf } from '@angular/common';

import { AdvertisementService } from '../services/advertisement.service';
import { Advertisement } from '../model/advertisement.model';
import { Skill } from '../../shared/models/skill.model';
import { SkillNamePipe } from '../pipes/skill-name.pipe';
import { AdvertisementErrorComponent } from '../advertisement-error/advertisement-error.component';

@Component({
  selector: 'app-advertisement-details',
  standalone: true,
  imports: [NgFor, NgIf, SkillNamePipe, AdvertisementErrorComponent, DatePipe],
  templateUrl: './advertisement-details.component.html',
  styleUrl: './advertisement-details.component.css'
})
export class AdvertisementDetailsComponent implements OnInit {

  skills: Skill[];

  constructor(
    private advertisementService: AdvertisementService,
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  advertisement: Advertisement;
  invalidData: boolean = false;

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.advertisement = data['advertisement'];
      this.skills = data['skills'];
      this.invalidData = 
        !this.advertisement || 
        (this.skills.length === 0 && this.advertisement.skills.length > 0);
    });
  };

  onOpen() {
    window.open(this.advertisement.url, "_blank");
  }

  onEdit() {
    this.router.navigate(['advertisements', this.advertisement.id, 'edit']);
  }

  onApply() {
    this.advertisementService.apply(this.advertisement);
  }
}
