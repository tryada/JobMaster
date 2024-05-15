import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

import { Advertisement } from '../model/advertisement.model';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  advertisementsChanged = new Subject<Advertisement[]>();
  advertisements = [
    new Advertisement(1, 'Angular Developer', 'Google', 'We are looking for an Angular Developer', 'https://www.google.com', [
      { id: 1, name: 'Angular' },
      { id: 2, name: 'TypeScript' },
    ], false, null, false),
    new Advertisement(2, 'React Developer', 'Microsoft', 'We are looking for a React Developer', 'https://www.google.com', [
      { id: 3, name: 'React' },
      { id: 4, name: 'JavaScript' },
    ], true, new Date(2024, 9, 1), false),
    new Advertisement(3, 'Vue Developer', 'Facebook', 'We are looking for a Vue Developer', 'https://www.google.com', [
      { id: 5, name: 'Vue' },
      { id: 6, name: 'JavaScript' },
    ], true, new Date(2024, 10, 9), true)
  ];

  getAdvertisements() {
    return this.advertisements.slice();
  }

  getAdvertisement(id: number) {
    return this.advertisements.find(a => a.id === id);
  }

  apply(advertisement: Advertisement) {
    advertisement.applied = true;
    advertisement.appliedDate = new Date();

    let index = this.advertisements.findIndex(a => a.id === advertisement.id);
    this.advertisements[index] = advertisement;
    this.advertisementsChanged.next(this.getAdvertisements());
  }

  deleteAdvertisement(id: number) {
    let index = this.advertisements.findIndex(a => a.id === id);
    this.advertisements.splice(index, 1);
    this.advertisementsChanged.next(this.getAdvertisements());
  }

  saveAdvertisement(advertisement: Advertisement) {
    if (advertisement.id) {
      let index = this.advertisements.findIndex(a => a.id === advertisement.id);
      this.advertisements[index] = advertisement;
    } else {
      advertisement.id = this.advertisements.length + 1;
      this.advertisements.push(advertisement);
    }
    this.advertisementsChanged.next(this.getAdvertisements());
  }
}
