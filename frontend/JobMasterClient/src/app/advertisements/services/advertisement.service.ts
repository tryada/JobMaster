import { Injectable } from '@angular/core';
import { Advertisement } from '../model/advertisement.model';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  advertisements = [
    new Advertisement(1, 'Angular Developer', 'We are looking for an Angular Developer', 'https://www.google.com', [
      { id: 1, name: 'Angular' },
      { id: 2, name: 'TypeScript' },
    ], false, null, false),
    new Advertisement(2, 'React Developer', 'We are looking for a React Developer', 'https://www.google.com', [
      { id: 3, name: 'React' },
      { id: 4, name: 'JavaScript' },
    ], true, new Date(2024, 9, 1), false),
    new Advertisement(3, 'Vue Developer', 'We are looking for a Vue Developer', 'https://www.google.com', [
      { id: 5, name: 'Vue' },
      { id: 6, name: 'JavaScript' },
    ], false, new Date(2024, 10, 9), true),
  ];

  getAdvertisements() {
    return this.advertisements.slice();
  }

  getAdvertisement(id: number) {
    return this.advertisements.find(a => a.id === id);
  }
}
