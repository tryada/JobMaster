import { HttpBackend, HttpClient, HttpErrorResponse, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Subject, catchError, of, tap } from 'rxjs';

import { environment } from '../../../environments/environment';
import { AuthData } from '../models/auth-data.model';
import { AuthResult } from '../models/auth-result.model';
import { AuthDataService } from './auth-data.service';
import { ErrorService } from '../../shared/services/error.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authDataSubject = new BehaviorSubject<AuthData>(null);
  invalidRequestOccurred = new Subject<string>();

  private httpClient: HttpClient;

  private loginUrl = environment.apiUrl + 'authentication/login';
  private registerUrl = environment.apiUrl + 'authentication/register';

  private errorMessages: Record<number, string> = {
    [HttpStatusCode.BadRequest]: "Niepoprawne dane",
    [HttpStatusCode.Conflict]: "Konto o podanym adresie email już istnieje"
  }

  get validAuthData(): AuthData {
    const authData = this.authDataSubject.value;
    if (!authData || !authData.isValid)
      return null;

    return this.authDataSubject.value;
  }

  get isAuthenticated(): boolean {
    return !!this.validAuthData;
  }

  constructor(
    httpBackend: HttpBackend,
    private router: Router,
    private authDataService: AuthDataService,
    private errorService: ErrorService) {
    this.httpClient = new HttpClient(httpBackend);
  }

  signUp(
    firstName: string,
    lastName: string,
    email: string,
    password: string) {
    return this.httpClient.post<AuthResult>(
      this.registerUrl,
      {
        firstName: firstName,
        lastName: lastName,
        email: email,
        password: password
      })
      .pipe(
        tap(this.handleAuthentication.bind(this)),
        catchError(this.handleAuthenticationError.bind(this))
      );
  }

  signIn(
    email: string,
    password: string) {
    return this.httpClient.post<AuthResult>(
      this.loginUrl,
      {
        email: email,
        password: password
      })
      .pipe(
        tap(this.handleAuthentication.bind(this)),
        catchError(this.handleAuthenticationError.bind(this))
      );
  }

  private handleAuthentication(result: AuthResult) {
    const authData = this.authDataService.create(result);
    this.authDataService.save(authData);
    this.authDataSubject.next(authData);
  }

  private handleAuthenticationError(error: HttpErrorResponse) {
    if (this.errorMessages[error.status])
      this.invalidRequestOccurred.next(this.errorMessages[error.status]);
    else
      this.errorService.handleError(error);

    return of(null);
  }

  autoSignIn() {
    const data = this.authDataService.load();
    if (!data || !data.isValid)
      return;

    this.authDataSubject.next(data);
  }

  signOut() {
    this.authDataSubject.next(null);
    this.router.navigate(['/auth']);
    this.authDataService.clear();
  }
}
