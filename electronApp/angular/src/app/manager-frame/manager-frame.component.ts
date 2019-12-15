import { Component, OnInit, ViewChildren, Input, ViewChild } from '@angular/core';
import { HeroSquareComponent } from '../components/hero-square/hero-square.component';
import { AppComponent } from '../app.component';
import { TimerComponent } from '../components/timer/timer.component';
import { TipsComponent } from '../components/tips/tips.component';

@Component({
  selector: 'app-manager-frame',
  templateUrl: './manager-frame.component.html',
  styleUrls: ['./manager-frame.component.scss']
})
export class ManagerFrameComponent implements OnInit {
  @ViewChildren(HeroSquareComponent) heroSquares
  @ViewChild(TimerComponent, { static: true }) Timer
  @ViewChild(TipsComponent,{static:true}) Tip
  @Input() that: AppComponent
  statusClass() {
    if (this.status == Status.Waiting) {
      return 'statusWaiting'
    }
    else {
      return 'statusOther'
    }
  }
  status: Status = Status.Waiting
  lastStatus: Status
  protected buttons: string[] = ['go', 'reset', 'back', 'home', 'exit', 'pause', 'continue', 'restart']
  protected heroBlue = 'blue'
  protected heroRed = 'red'
  protected heroManagerAct: string = ''
  protected blueNum = 0
  protected redNum = 0
  constructor() { }

  ngOnInit() {
  }
  managerFrameOut() {
    this.heroManagerAct = 'heroManagerAct'
  }
  gone() {
    this.heroManagerAct = 'gone'
  }

  //处理接收的英雄数据
  setHeroInf(codes: string[]) {
    let squareId: number = Number(codes[1])
    codes.shift()
    this.heroSquares._results[squareId].init(codes)
  }
  setHeroNum(codes: string[]) {
    switch (codes[1]) {
      case 'redNum':
        this.redNum = Number(codes[2])
        break
      case 'blueNum':
        this.blueNum = Number(codes[2])
        break
    }
  }
  setHeroLevel(codes: string[]) {
    let squareId: number = Number(codes[1])
    let heroLevel: number = Number(codes[2])
    this.heroSquares._results[squareId].setHeroLevel(heroLevel)
  }
  setInit(codes: string[]){
    let squareId: number = Number(codes[1])
    this.heroSquares._results[squareId].init()
  }

  //提供给子组件的通信方式
  setHeroPlace(heroSquareId: number, hero: string) {
    let code: string = 'setHeroPlace ' + heroSquareId + ' ' + hero
    this.that.send(code)
  }
  changeHeroLevel(heroSquareId: number) {
    let code: string = 'changeHeroLevel ' + heroSquareId
    this.that.send(code)
  }

  //按钮操作
  pause() {
    this.Timer.pause()
    this.status = Status.pausing
    this.lastStatus = Status.pausing
  }
  continue() {
    this.Timer.continue()
    this.status = Status.Fighting
  }
  restart() {

  }
  reset() {
    for (var i = 0; i < 55; i++) {
      this.heroSquares._results[i].init()
    }
    let code: string = 'reset'
    this.that.send(code)
  }
  exit() {
    this.that.exitFrameOut()
  }
  home() {
    this.gone()
    this.that.managerToHome()
  }
  back() {
    switch (this.status) {
      case Status.Waiting:
        this.gone()
        setTimeout(() => this.that.managerToHome(), 310);
        break
      case Status.pausing:
        this.status = Status.Waiting
        break
    }
  }
  go() {
    if (this.lastStatus == null){
      this.status = Status.Fighting
      this.Timer.TimeReady()
    }
    else {
      this.status = this.lastStatus
    }
  }
}
export enum Status { Fighting, Waiting, pausing, end }