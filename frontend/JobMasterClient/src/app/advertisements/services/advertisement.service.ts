import { Injectable } from '@angular/core';
import { Subject, catchError, concatMap, lastValueFrom, map, of } from 'rxjs';

import { Advertisement } from '../model/advertisement.model';
import { UserHttpClient } from '../../global/services/user-http-client.service';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  advertisementsChanged = new Subject<Advertisement[]>();

  constructor(private httpClient: UserHttpClient) { }

  getAdvertisements() {
    return this.httpClient
      .get<Advertisement[]>('advertisements')
      .pipe(
        map(advertisements => advertisements),
        catchError(() => of([]))
      );
  }

  getAdvertisement(id: string) {
    return this.httpClient
      .get<Advertisement>('advertisements/' + id)
      .pipe(
        map(advertisement => advertisement),
        catchError(() => {
          return of(null);
        })
      );
  }

  apply(advertisement: Advertisement) {
    advertisement.applied = true;
    advertisement.appliedDate = new Date();
    this.saveAdvertisement(advertisement)
  }

  deleteAdvertisement(id: string) {

    this.httpClient.delete('advertisements/' + id)
      .pipe(
        concatMap(() => this.getAdvertisements())
      ).subscribe(advertisements => {
        this.advertisementsChanged.next(advertisements);
      });
  }

  async saveAdvertisement(advertisement: Advertisement) {

    if (advertisement.id === null) {
      await lastValueFrom(this.httpClient.post('advertisements', advertisement));
    } else {
      await lastValueFrom(this.httpClient.put('advertisements/' + advertisement.id, advertisement));
    }

    const advertisements = await lastValueFrom(this.getAdvertisements());
    this.advertisementsChanged.next(advertisements);
  }
}