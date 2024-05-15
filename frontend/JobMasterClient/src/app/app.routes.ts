import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AdvertisementsComponent } from './advertisements/advertisements.component';
import { ProfileComponent } from './profile/profile.component';
import { AdvertisementEditComponent } from './advertisements/advertisement-edit/advertisement-edit.component';
import { AdvertisementDetailsComponent } from './advertisements/advertisement-details/advertisement-details.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    {
        path: 'advertisements', component: AdvertisementsComponent, children: [
            { path: 'new', component: AdvertisementEditComponent },
            { path: ':id', component: AdvertisementDetailsComponent },
            { path: ':id/edit', component: AdvertisementEditComponent }
        ]
    },
    { path: 'profile', component: ProfileComponent },
];