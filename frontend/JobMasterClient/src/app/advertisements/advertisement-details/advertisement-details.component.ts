import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgFor } from '@angular/common';

import { AdvertisementService } from '../services/advertisement.service';
import { Advertisement } from '../model/advertisement.model';

@Component({
  selector: 'app-advertisement-details',
  standalone: true,
  imports: [NgFor],
  templateUrl: './advertisement-details.component.html',
  styleUrl: './advertisement-details.component.css'
})
export class AdvertisementDetailsComponent implements OnInit {

  constructor(
    private advertisementService: AdvertisementService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  advertisement: Advertisement;

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.advertisement = this.advertisementService.getAdvertisement(+params['id']);
      })
  };

  onOpen() {
    window.open(this.advertisement.url, "_blank");
  }

  onEdit() {
    this.router.navigate(['advertisements', this.advertisement.id, 'edit']);
  }

  onDelete() {

  }
}
