import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AdvertisementsComponent } from './advertisements/advertisements.component';
import { ProfileComponent } from './profile/profile.component';
import { AdvertisementEditComponent } from './advertisements/advertisement-edit/advertisement-edit.component';
import { AdvertisementDetailsComponent } from './advertisements/advertisement-details/advertisement-details.component';
import { advertisementsResolver } from './advertisements/resolvers/advertisements.resolver';
import { advertisementResolver } from './advertisements/resolvers/advertisement.resolver';
import { skillsResolver } from './shared/resolvers/skills.resolver';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    {
        path: 'advertisements', 
        component: AdvertisementsComponent, 
        resolve: { advertisements: advertisementsResolver }, 
        children: [
            { path: 'new', component: AdvertisementEditComponent, resolve: 
                { skills: skillsResolver }},
            { path: ':id', component: AdvertisementDetailsComponent, 
                resolve: { advertisement: advertisementResolver, skills: skillsResolver}},
            { path: ':id/edit', component: AdvertisementEditComponent, resolve: 
                { advertisement: advertisementResolver, skills: skillsResolver}}
        ]
    },
    { path: 'profile', component: ProfileComponent },
];