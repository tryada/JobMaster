import { HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";

import { AuthService } from "../services/auth.service";

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
    
    const authService = inject(AuthService);
    
    var authData = authService.validAuthData;
    if (!authData)
        return next(req);

    const authRequest = req.clone({
        setHeaders: {
            Authorization: `Bearer ${authData.token}`
        }
    });
    return next(authRequest);
};