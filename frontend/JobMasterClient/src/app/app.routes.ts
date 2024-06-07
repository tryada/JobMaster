import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AdvertisementsComponent } from './advertisements/advertisements.component';
import { ProfileComponent } from './profile/profile.component';
import { AdvertisementEditComponent } from './advertisements/advertisement-edit/advertisement-edit.component';
import { AdvertisementDetailsComponent } from './advertisements/advertisement-details/advertisement-details.component';
import { advertisementsResolver } from './advertisements/resolvers/advertisements.resolver';
import { advertisementResolver } from './advertisements/resolvers/advertisement.resolver';
import { skillsResolver } from './shared/resolvers/skills.resolver';
import { AuthComponent } from './auth/auth.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AuthGuard } from './auth/guards/auth.guard';
import { AnonymousGuard } from './auth/guards/anonymous.guard';
import { SkillsComponent } from './skills/skills.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
    {
        path: 'advertisements',
        component: AdvertisementsComponent,
        resolve: { advertisements: advertisementsResolver },
        canActivate: [AuthGuard],
        children: [
            {
                path: 'new', component: AdvertisementEditComponent, resolve:
                    { skills: skillsResolver }
            },
            {
                path: ':id', component: AdvertisementDetailsComponent,
                resolve: { advertisement: advertisementResolver, skills: skillsResolver }
            },
            {
                path: ':id/edit', component: AdvertisementEditComponent, resolve:
                    { advertisement: advertisementResolver, skills: skillsResolver }
            }
        ]
    },
    {
        path: 'skills',
        component: SkillsComponent,
        canActivate: [AuthGuard]
    },
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},
    {
        path: 'auth',
        component: AuthComponent,
        canActivate: [AnonymousGuard],
        children: [
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent }
        ]
    }
];