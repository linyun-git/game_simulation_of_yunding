import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timer'
})
export class TimerPipe implements PipeTransform {

  transform(time: number): string {
    if (time < 10)
      return '0' + time
    else
      return time.toString()
  }

}
