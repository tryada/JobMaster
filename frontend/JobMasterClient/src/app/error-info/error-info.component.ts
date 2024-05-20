import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-error-info',
  standalone: true,
  imports: [],
  templateUrl: './error-info.component.html',
})
export class ErrorInfoComponent {

  @Input({required: true}) errorMessage: string;
  @Output() close = new EventEmitter<void>();

}