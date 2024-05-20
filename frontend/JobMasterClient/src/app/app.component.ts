import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { HeaderComponent } from './header/header.component';
import { ErrorInfoComponent } from './error-info/error-info.component';
import { ErrorService } from './shared/services/error.service';
import { Subscription } from 'rxjs';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, ErrorInfoComponent, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, OnDestroy {

  private errorSubscription: Subscription;
  errorMessage: string;

  constructor(private errorService: ErrorService) { }

  ngOnInit(): void {
    this.errorSubscription = this.errorService.onError.subscribe(errorMessage => {
      this.errorMessage = errorMessage;
    });
  }

  ngOnDestroy(): void {
    this.errorSubscription.unsubscribe();
  }

  onErrorClose() {
    this.errorMessage = null;
  }
}
