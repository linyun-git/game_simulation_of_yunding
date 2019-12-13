import { Component, OnInit,Input } from '@angular/core';
import { TipsComponent } from '../tips/tips.component';

var time,pausetime
@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent implements OnInit {
  @Input() Tip:TipsComponent
  protected textColor:string = 'white'
  private maxTime:number
  imgsrc = 'whiteTime'
  rotate: number = 0
  public thisTime
  setTime: number
  pauseTime:number = 0
  timerun:boolean = true
  fun:any
  constructor() { }

  ngOnInit() {
  }
  TimeReady(){
    this.Tip.giveTip('Ready!')
    this.textColor = 'white'
    this.imgsrc = 'whiteTime'
    time = new Date()
    this.thisTime = time.getTime()
    this.maxTime = 3
    this.fun = (()=>{
      this.FightStart()
    })
    this.run()
  }
  TimeOut(){
    this.Tip.giveTip('Timeout!')
    this.pauseTime = 0
    this.textColor = 'red'
    this.imgsrc = 'redTime'
    time = new Date()
    this.thisTime = time.getTime()
    this.maxTime = 10
    this.fun = (()=>{
    })
    this.run()
  }
  FightStart(){
    this.Tip.giveTip('Fight!')
    this.pauseTime = 0
    this.textColor = 'white'
    this.imgsrc = 'whiteTime'
    time = new Date()
    this.thisTime = time.getTime()
    this.maxTime = 30
    this.fun = (()=>{
      this.TimeOut()
    })
    this.run()
  }

  private run(){
    let time = new Date()
    let t = time.getTime() - this.thisTime-this.pauseTime
    let num = this.maxTime - parseInt((t / 1000).toString())
    this.rotate = 15 * parseInt((t * 24 / 1000).toString())
    this.setTime = num
    if(num > 0&&this.timerun){
      setTimeout(() => {
        this.run()
      }, 40);
    }
    else if(num == 0){
      this.fun()
    }
  }
  pause(){
    this.timerun = false
    pausetime = new Date()
  }
  continue(){
    this.timerun = true
    this.pauseTime += (new Date()).getTime()-pausetime.getTime()
    this.run()
  }
}