import { Component, OnInit } from '@angular/core';

var time
@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent implements OnInit {
  imgsrc = 'whiteTime'
  rotate: number = 0
  public thisTime
  setTime: number
  constructor() { }

  ngOnInit() {
    time = new Date()
    this.start()
  }
  start() {
    this.thisTime = time.getTime()
    this.run()
  }
  run() {
    let time = new Date()
    let t = time.getTime() - this.thisTime
    let num = 30 - parseInt((t / 1000).toString())
    this.rotate = 15 * parseInt((t * 24 / 1000).toString())
    this.setTime = num
    if(num > 0){
      setTimeout(() => {
        this.run()
      }, 40);
    }
  }
}
