import { Injectable } from '@angular/core';
import { Subject, catchError, concatMap, lastValueFrom, map, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { Advertisement } from '../model/advertisement.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  advertisementsChanged = new Subject<Advertisement[]>();

  constructor(private httpClient: HttpClient) { }

  getAdvertisements() {
    return this.httpClient
      .get<Advertisement[]>(environment.apiUrl + 'advertisements')
      .pipe(
        map(advertisements => advertisements),
        catchError(() => of([]))
      );
  }

  getAdvertisement(id: string) {
    return this.httpClient
      .get<Advertisement>(environment.apiUrl + 'advertisements/' + id)
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

    this.httpClient.delete(environment.apiUrl + 'advertisements/' + id)
      .pipe(
        concatMap(() => this.getAdvertisements())
      ).subscribe(advertisements => {
        this.advertisementsChanged.next(advertisements);
      });
  }

  async saveAdvertisement(advertisement: Advertisement) {

    if (advertisement.id === null) {
      await lastValueFrom(this.httpClient.post(environment.apiUrl + 'advertisements', advertisement));
    } else {
      await lastValueFrom(this.httpClient.put(environment.apiUrl + 'advertisements/' + advertisement.id, advertisement));
    }

    const advertisements = await lastValueFrom(this.getAdvertisements());
    this.advertisementsChanged.next(advertisements);
  }
}