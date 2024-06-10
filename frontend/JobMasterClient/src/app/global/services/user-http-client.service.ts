import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { environment } from "../../../environments/environment";

@Injectable({
    providedIn: 'root'
})
export class UserHttpClient {

    constructor(private httpClient: HttpClient) { }

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
        return environment.apiUrl + 'users/me/' + url;
    }
}