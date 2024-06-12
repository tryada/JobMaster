import { Component } from '@angular/core';
import { AdvertisementsStatisticsComponent } from './advertisements-statistics/advertisements-statistics.component';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [AdvertisementsStatisticsComponent],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {

}
