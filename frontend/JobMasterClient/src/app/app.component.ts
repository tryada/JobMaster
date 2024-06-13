import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgIf } from '@angular/common';
import { Subscription } from 'rxjs';

import { HeaderComponent } from './header/header.component';
import { ErrorInfoComponent } from './error-info/error-info.component';
import { ErrorService } from './shared/services/error.service';
import { AuthService } from './auth/services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, ErrorInfoComponent, NgIf],
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit, OnDestroy {

  private errorSubscription: Subscription;
  errorMessage: string;

  constructor(
    private errorService: ErrorService,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.errorSubscription = this.errorService.onError.subscribe(errorMessage => {
      this.errorMessage = errorMessage;
    });

    this.authService.autoSignIn();
  }

  ngOnDestroy(): void {
    this.errorSubscription.unsubscribe();
  }

  onErrorClose() {
    this.errorMessage = null;
  }
}
