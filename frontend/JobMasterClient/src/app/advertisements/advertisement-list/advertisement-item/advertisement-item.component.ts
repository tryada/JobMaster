import { DatePipe, NgFor, NgIf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

import { TruncatePipe } from '../../../shared/pipes/truncate.pipe';
import { YesNoPipe } from '../../../shared/pipes/yes-no.pipe';
import { Advertisement } from '../../model/advertisement.model';
import { AdvertisementService } from '../../services/advertisement.service';

@Component({
  selector: 'app-advertisement-item',
  standalone: true,
  imports: [NgIf, NgFor, TruncatePipe, YesNoPipe, DatePipe],
  templateUrl: './advertisement-item.component.html',
  styleUrl: './advertisement-item.component.css'
})
export class AdvertisementItemComponent {

  @Input({ required: true }) advertisement: Advertisement;

  constructor(
    private router: Router,
    private advertisementService: AdvertisementService) { }

  onMore() {
    this.router.navigate(['advertisements', this.advertisement.id]);
  }

  onEdit() {
    this.router.navigate(['advertisements', this.advertisement.id, 'edit']);
  }

  onApply() {
    this.advertisementService.apply(this.advertisement);
  }
}

