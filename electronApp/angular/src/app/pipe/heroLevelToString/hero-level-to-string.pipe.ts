import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'heroLevelToString'
})
export class HeroLevelToStringPipe implements PipeTransform {
  transform(heroLevel: number): string {
    switch (heroLevel) {
      case 1:
        return 'levelOne'
      case 2:
        return 'levelTwo'
      case 3:
        return 'levelThree'
    }
  }
}
