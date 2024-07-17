import { Injectable } from '@angular/core';
import { catchError, map, of } from 'rxjs';

import { UserHttpClient } from '../../global/services/user-http-client.service';
import { AdvertisementsStatistics } from '../models/advertisements-statistic.model';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {

  constructor(private httpClient: UserHttpClient) { }

  getAdvertisementsStatistics() {
    return this.httpClient
      .get<AdvertisementsStatistics>('statistics/advertisements')
      .pipe(
        map(statistics => statistics),
        catchError(() => of({
          count: 0,
          appliedCount: 0,
          repliedCount: 0,
          rejectedCount: 0
        }))
      );
  }
}