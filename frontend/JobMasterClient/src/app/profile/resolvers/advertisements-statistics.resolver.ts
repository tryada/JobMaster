import { ResolveFn } from '@angular/router';
import { inject } from '@angular/core';

import { StatisticsService } from '../services/statistics.service';
import { AdvertisementsStatistics } from '../models/advertisements-statistic.model';

export const advertisementsStatisticsResolver: ResolveFn<AdvertisementsStatistics> = (route, state) => {

  const statisticsService = inject(StatisticsService);
  return statisticsService.getAdvertisementsStatistics();
};
