import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { ErrorInterceptor } from './http-interceptors/error.interceptor';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

import { routes } from './app.routes';
import { AuthInterceptor } from './auth/interceptors/auth.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 
    provideHttpClient(
      withInterceptors([
        ErrorInterceptor, 
        AuthInterceptor
      ])
    )
  ]
};
