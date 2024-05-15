import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { AdvertisementEditComponent } from './advertisement-edit/advertisement-edit.component';
import { AdvertisementListComponent } from './advertisement-list/advertisement-list.component';

@Component({
  selector: 'app-advertisements',
  standalone: true,
  imports: [RouterOutlet, AdvertisementEditComponent, AdvertisementListComponent],
  templateUrl: './advertisements.component.html',
  styleUrl: './advertisements.component.css'
})
export class AdvertisementsComponent {

}
