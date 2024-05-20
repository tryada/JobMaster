import { HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { catchError } from "rxjs";

import { ErrorService } from "../shared/services/error.service";

export const ErrorInterceptor: HttpInterceptorFn = (req, next) => {

    const errorService = inject(ErrorService);

    return next(req)
        .pipe(
            catchError(error => {
                errorService.handleError(error);
                throw error;
            })
        );
}