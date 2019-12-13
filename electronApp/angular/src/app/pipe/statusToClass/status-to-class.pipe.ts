import { Pipe, PipeTransform } from '@angular/core';
import { Status } from '../../manager-frame/manager-frame.component';

@Pipe({
  name: 'statusToClass'
})
export class StatusToClassPipe implements PipeTransform {

  transform(status: Status): string {
    switch (status) {
      case Status.Waiting:
        return 'statusWaiting'
      case Status.Fighting:
        return 'statusFighting'
      case Status.pausing:
        return 'statusPausing'
      case Status.end:
        return 'statusEnd'
    }
  }

}
