export class AuthData {
    constructor(
        public id: string,
        private _token: string,
        private _expirationDate: Date) {
    }

    get token() {
        if (!this.expirationDate || this.expirationDate < new Date()) {
            return null;
        }
        return this._token;
    }

    get expirationDate() {
        return this._expirationDate;
    }

    get isValid() {
        return this.token !== null;
    }
}