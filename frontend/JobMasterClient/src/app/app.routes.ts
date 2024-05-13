import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AdvertisementsComponent } from './advertisements/advertisements.component';
import { ProfileComponent } from './profile/profile.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'advertisements', component: AdvertisementsComponent },
    { path: 'profile', component: ProfileComponent },
];