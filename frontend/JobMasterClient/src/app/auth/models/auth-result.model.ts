export interface AuthResult {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    token: string;
    expirationDate: Date;
}