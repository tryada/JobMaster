import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { ErrorInterceptor } from './http-interceptors/error.interceptor';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 
    provideHttpClient(withInterceptors([ErrorInterceptor]))
  ]
};
