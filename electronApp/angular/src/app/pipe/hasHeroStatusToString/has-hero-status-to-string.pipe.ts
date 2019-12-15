import { Pipe, PipeTransform } from '@angular/core';
import { hasHeroStatus } from '../../components/hero-square/hero-square.component';

@Pipe({
  name: 'hasHeroStatusToString'
})
export class HasHeroStatusToStringPipe implements PipeTransform {

  transform(status: hasHeroStatus): string {
    switch (status) {
      case hasHeroStatus.hasHeroTrue:
        return 'hasHeroTrue'
        break
      case hasHeroStatus.hasHeroFalse:
        return 'hasHeroFalse'
        break
    }
  }

}
