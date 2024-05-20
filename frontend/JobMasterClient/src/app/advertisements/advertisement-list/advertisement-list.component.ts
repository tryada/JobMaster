import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

import { AdvertisementService } from '../services/advertisement.service';
import { Advertisement } from '../model/advertisement.model';
import { AdvertisementItemComponent } from './advertisement-item/advertisement-item.component';

@Component({
  selector: 'app-advertisement-list',
  standalone: true,
  imports: [NgFor, NgIf, AdvertisementItemComponent, RouterLink],
  templateUrl: './advertisement-list.component.html',
  styleUrl: './advertisement-list.component.css'
})
export class AdvertisementListComponent implements OnInit, OnDestroy {

  constructor(
    private advertisementService: AdvertisementService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  advertisements: Advertisement[]
  subscription: Subscription;

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.advertisements = data['advertisements'];
    })

    this.subscription = this.advertisementService.advertisementsChanged.subscribe(
      (advertisements: Advertisement[]) => {
        this.advertisements = advertisements;
      }
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  onAddAdvertisement(): void {
    this.router.navigate(['new'], { relativeTo: this.route });
  }
}
