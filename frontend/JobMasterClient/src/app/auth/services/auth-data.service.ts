import { Injectable } from "@angular/core";
import { StorageService } from "../../global/services/storage.service";
import { AuthData } from "../models/auth-data.model";
import { AuthResult } from "../models/auth-result.model";

@Injectable({
    providedIn: 'root'
})
export class AuthDataService {

    constructor(private storageService: StorageService) { }

    private userId_storageKey: string = 'user_id';
    private token_storageKey: string = 'token';
    private expirationDate_storageKey: string = 'expiration_date';

    create(authResult: AuthResult) : AuthData {
        return new AuthData(
            authResult.id,
            authResult.token,
            authResult.expirationDate);
    }

    save(authData: AuthData) {
        this.storageService.setItem(this.userId_storageKey, authData.id);
        this.storageService.setItem(this.token_storageKey, authData.token);
        this.storageService.setItem(this.expirationDate_storageKey, authData.expirationDate);
    }

    load(): AuthData {
        const userId = this.storageService.getItem(this.userId_storageKey);
        const token = this.storageService.getItem(this.token_storageKey);
        const expirationDate = new Date(this.storageService.getItem(this.expirationDate_storageKey));

        if (!userId || !token || !expirationDate)
            return null;

        const data = new AuthData(userId, token, expirationDate);
        
        if (!data.isValid) {
            this.clear();
            return null;
        }

        return data;
    }

    clear() {
        this.storageService.removeItem(this.userId_storageKey);
        this.storageService.removeItem(this.token_storageKey);
        this.storageService.removeItem(this.expirationDate_storageKey);
    }
}