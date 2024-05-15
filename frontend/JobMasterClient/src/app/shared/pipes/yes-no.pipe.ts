import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'yesno',
  standalone: true
})
export class YesNoPipe implements PipeTransform {

  transform(value: boolean): string {
    if (value) {
      return 'Tak';
    } else {
      return 'Nie';
    }
  }
}
