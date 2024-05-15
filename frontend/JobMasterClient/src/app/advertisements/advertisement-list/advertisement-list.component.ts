import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgFor } from '@angular/common';
import { Subscription } from 'rxjs';

import { AdvertisementService } from '../services/advertisement.service';
import { Advertisement } from '../model/advertisement.model';
import { AdvertisementItemComponent } from './advertisement-item/advertisement-item.component';

@Component({
  selector: 'app-advertisement-list',
  standalone: true,
  imports: [NgFor, AdvertisementItemComponent],
  templateUrl: './advertisement-list.component.html',
  styleUrl: './advertisement-list.component.css'
})
export class AdvertisementListComponent implements OnInit, OnDestroy {

  subscription: Subscription;

  constructor(
    private advertisementService: AdvertisementService,
  ) { }

  advertisements: Advertisement[]

  ngOnInit(): void {
    this.advertisements = this.advertisementService.getAdvertisements();
    this.subscription = this.advertisementService.advertisementsChanged.subscribe((advertisements: Advertisement[]) => {
      this.advertisements = advertisements;
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
