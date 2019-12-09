import { Pipe, PipeTransform } from '@angular/core';
import { Status } from '../../manager-frame/manager-frame.component';

@Pipe({
  name: 'statusEqualsWaiting'
})
export class StatusEqualsWaitingPipe implements PipeTransform {

  transform(status: Status): boolean {
    if (status == Status.Waiting)
      return true;
    else
      return false;
  }
}
