import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgFor } from '@angular/common';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

import { AdvertisementService } from '../services/advertisement.service';
import { Advertisement } from '../model/advertisement.model';
import { AdvertisementItemComponent } from './advertisement-item/advertisement-item.component';

@Component({
  selector: 'app-advertisement-list',
  standalone: true,
  imports: [NgFor, AdvertisementItemComponent, RouterLink],
  templateUrl: './advertisement-list.component.html',
  styleUrl: './advertisement-list.component.css'
})
export class AdvertisementListComponent implements OnInit, OnDestroy {

  subscription: Subscription;

  constructor(
    private advertisementService: AdvertisementService,
    private router: Router,
    private route: ActivatedRoute
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

  onAddAdvertisement() {
      this.router.navigate(['new'], { relativeTo: this.route });
  }
}
