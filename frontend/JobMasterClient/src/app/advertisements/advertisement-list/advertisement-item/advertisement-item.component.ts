import { DatePipe, NgFor, NgIf } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

import { TruncatePipe } from '../../../shared/pipes/truncate.pipe';
import { Advertisement } from '../../model/advertisement.model';

@Component({
  selector: 'app-advertisement-item',
  standalone: true,
  imports: [NgIf, NgFor, TruncatePipe, DatePipe, RouterLink, RouterLinkActive],
  templateUrl: './advertisement-item.component.html'
})
export class AdvertisementItemComponent {

  @Input({ required: true }) advertisement: Advertisement;

}

