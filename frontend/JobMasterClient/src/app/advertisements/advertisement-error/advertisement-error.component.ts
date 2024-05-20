import { Component } from '@angular/core';

@Component({
  selector: 'app-advertisement-error',
  standalone: true,
  imports: [],
  template: `    
  <div class="alert alert-danger" role="alert">
    Nie można załadować ogłoszenia.
  </div>`
})
export class AdvertisementErrorComponent {

}
