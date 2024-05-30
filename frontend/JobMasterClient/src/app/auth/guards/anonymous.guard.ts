import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";

import { AuthService } from "../services/auth.service";

export const AnonymousGuard: CanActivateFn = () => {

    const authService = inject(AuthService);
    const router = inject(Router);
    
    if (authService.isAuthenticated) {
        router.navigate(['/home']);
        return false;
    }

    return true;
};