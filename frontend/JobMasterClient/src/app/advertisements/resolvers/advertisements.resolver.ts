import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from '@angular/router';

import { AdvertisementService } from '../services/advertisement.service';
import { Advertisement } from '../model/advertisement.model';

export const advertisementsResolver: ResolveFn<Advertisement[]> = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {

  const advertisementService = inject(AdvertisementService);
  return advertisementService.getAdvertisements();
};