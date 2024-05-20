import { ResolveFn } from '@angular/router';
import { inject } from '@angular/core';

import { AdvertisementService } from '../services/advertisement.service';
import { Advertisement } from '../model/advertisement.model';

export const advertisementResolver: ResolveFn<Advertisement> = (route, state) => {

  const advertisementService = inject(AdvertisementService);
  return advertisementService.getAdvertisement(route.params['id']);
};