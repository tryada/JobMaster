import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { NgIf } from '@angular/common';
import { Subscription } from 'rxjs';

import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, NgIf],
  templateUrl: './register.component.html',
  styles: `
    input.ng-invalid.ng-touched {
      border: 1px solid red;
    }
  `})
export class RegisterComponent implements OnInit, OnDestroy {

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

  onSubmit(registerForm: NgForm) {
    this.error = null;

    this.authService.signUp(
      registerForm.value.firstName,
      registerForm.value.lastName,
      registerForm.value.email,
      registerForm.value.password
    )
    .subscribe(
      (data) => {
        if (data)
          this.router.navigate(['/advertisements'])
      } 
    )
  }

  onSignIn() {
    this.router.navigate(['..'], { relativeTo: this.route });
  }
}
