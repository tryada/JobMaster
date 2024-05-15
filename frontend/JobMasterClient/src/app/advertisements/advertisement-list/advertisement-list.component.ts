import { Component, OnInit } from '@angular/core';
import { DatePipe, NgFor } from '@angular/common';

import { AdvertisementService } from '../services/advertisement.service';
import { Advertisement } from '../model/advertisement.model';
import { TruncatePipe } from '../../shared/pipes/truncate.pipe';
import { YesNoPipe } from '../../shared/pipes/yes-no.pipe';
import { Router } from '@angular/router';

@Component({
  selector: 'app-advertisement-list',
  standalone: true,
  imports: [NgFor, DatePipe, TruncatePipe, YesNoPipe],
  templateUrl: './advertisement-list.component.html',
  styleUrl: './advertisement-list.component.css'
})
export class AdvertisementListComponent implements OnInit {

  constructor(
    private advertisementService: AdvertisementService,
    private router: Router
  ) { }

  advertisements: Advertisement[]

  ngOnInit(): void {
    this.advertisements = this.advertisementService.getAdvertisements();
  }

  onMore(id: number) {
    this.router.navigate(['advertisements', id]);
  }
}
