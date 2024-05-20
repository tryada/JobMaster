import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  onError: Subject<string> = new Subject<string>();

  handleError(error: any) {
    this.onError.next("Wystąpił błąd aplikacji. Spróbuj ponownie później.");
  }
}
