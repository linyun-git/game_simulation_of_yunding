import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'heroNameToSrc'
})
export class HeroNameToSrcPipe implements PipeTransform {
  transform(heroName: string): string {
      if (heroName != '') {
          return 'assets/img/' + heroName + '.png';
      }
      else
          return '';
  }
}
