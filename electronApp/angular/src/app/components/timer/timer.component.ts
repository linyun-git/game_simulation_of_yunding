import { Component, OnInit } from '@angular/core';

var time
@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent implements OnInit {
  protected textColor:string = 'white'
  private maxTime:number
  imgsrc = 'whiteTime'
  rotate: number = 0
  public thisTime
  setTime: number
  constructor() { }

  ngOnInit() {
    this.TimeReady()
  }
  TimeReady(){
    this.textColor = 'white'
    this.imgsrc = 'whiteTime'
    time = new Date()
    this.thisTime = time.getTime()
    this.maxTime = 3
    this.run(()=>{
      this.FightStart()
    })
  }
  TimeOut(){
    this.textColor = 'red'
    this.imgsrc = 'redTime'
    time = new Date()
    this.thisTime = time.getTime()
    this.maxTime = 10
    this.run(this.end)
  }
  FightStart(){
    this.textColor = 'white'
    this.imgsrc = 'whiteTime'
    time = new Date()
    this.thisTime = time.getTime()
    this.maxTime = 30
    this.run(()=>{
      this.TimeOut()
    })
  }

  private run(fun:any){
    let time = new Date()
    let t = time.getTime() - this.thisTime
    let num = this.maxTime - parseInt((t / 1000).toString())
    this.rotate = 15 * parseInt((t * 24 / 1000).toString())
    this.setTime = num
    if(num > 0){
      setTimeout(() => {
        this.run(fun)
      }, 40);
    }
    else if(num == 0){
      fun()
    }
  }
  end(){
    // alert('end')
  }
}