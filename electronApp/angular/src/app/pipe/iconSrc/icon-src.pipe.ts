import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'iconSrc'
})
export class IconSrcPipe implements PipeTransform {
  transform(icon: string): string {
    if (icon != '') {
      return 'assets/img/icon/' + icon + '.png';
    }
    else
      return '';
  }
}
