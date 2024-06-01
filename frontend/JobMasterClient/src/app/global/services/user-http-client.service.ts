import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { environment } from "../../../environments/environment";
import { AuthService } from "../../auth/services/auth.service";

@Injectable({
    providedIn: 'root'
})
export class UserHttpClient {

    private userUrl = 
        environment.apiUrl + 
        'users/' +
        this.authService.validAuthData.id +
        '/';

    constructor(
        private httpClient: HttpClient,
        private authService: AuthService
    ) { }
    
    get<T>(url: string) {
        return this.httpClient.get<T>(this.combineUrl(url));
    }

    post<T>(url: string, body: any) {
        return this.httpClient.post<T>(this.combineUrl(url), body);
    }

    put<T>(url: string, body: any) {
        return this.httpClient.put<T>(this.combineUrl(url), body);
    }

    delete<T>(url: string) {
        return this.httpClient.delete<T>(this.combineUrl(url));
    }

    private combineUrl(url: string) {
        return this.userUrl + url;
    }
}