import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgIf } from '@angular/common';
import { Subscription } from 'rxjs';

import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, NgIf],
  templateUrl: './login.component.html',
  styles: `
    input.ng-invalid.ng-touched {
      border: 1px solid red;
    }
  `})
export class LoginComponent implements OnInit, OnDestroy {

  error: string = null;
  private badRequestOccurredSubscription : Subscription;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService) { }

  ngOnInit() {
    this.badRequestOccurredSubscription = this.authService.invalidRequestOccurred.subscribe(
      (message) => {
        this.error = message;
      }
    );
  }

  ngOnDestroy() {
    this.badRequestOccurredSubscription.unsubscribe();
  }

  onSubmit(loginForm: NgForm) {
    this.error = null;

    this.authService.signIn(
      loginForm.value.email,
      loginForm.value.password
    )
    .subscribe(
      (res) => {
        if (res)
          this.router.navigate(['/advertisements'])
      }
    );
  }

  onSignUp() {
    this.router.navigate(['../register'], { relativeTo: this.route })
  }
}
