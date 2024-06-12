import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { AdvertisementsStatistics } from '../models/advertisements-statistic.model';

@Component({
  selector: 'app-advertisements-statistics',
  standalone: true,
  templateUrl: './advertisements-statistics.component.html'
})
export class AdvertisementsStatisticsComponent implements OnInit {

  statistics: AdvertisementsStatistics;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.statistics = data['advertisementsStatistics'];
    });
  }
}