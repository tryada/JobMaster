import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Subscription } from 'rxjs';
import { NgIf } from '@angular/common';

import { AuthService } from '../auth/services/auth.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NgIf],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit, OnDestroy {

  private userSubscription: Subscription;
  isAuthenticated = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.userSubscription = this.authService.authDataSubject.subscribe(authData => {
      this.isAuthenticated = authData ? authData.isValid : false;
    });
  };

  onSignOut(): void {
    this.authService.signOut();
  }

  ngOnDestroy(): void {
    this.userSubscription.unsubscribe();
  }
}
