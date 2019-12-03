import { Component, OnInit, ViewChildren,Input } from '@angular/core';
import { HeroSquareComponent } from '../components/hero-square/hero-square.component';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-manager-frame',
  templateUrl: './manager-frame.component.html',
  styleUrls: ['./manager-frame.component.scss']
})
export class ManagerFrameComponent implements OnInit {
  @ViewChildren(HeroSquareComponent) heroSquares
  @Input() that:AppComponent
  protected buttons:string[] = ['go','reset','back','home','exit']
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
  gone(){
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
  setHeroLevel(codes: string[]){
    let squareId: number = Number(codes[1])
    let heroLevel: number = Number(codes[2])
    this.heroSquares._results[squareId].setHeroLevel(heroLevel)
  }

  //提供给子组件的通信方式
  setHeroPlace(heroSquareId:number,hero:string){
    let code:string = 'setHeroPlace '+heroSquareId+' '+hero
    this.that.send(code)
  }
  changeHeroLevel(heroSquareId:number){
    let code:string = 'changeHeroLevel '+heroSquareId
    this.that.send(code)
  }

  //按钮操作
  reset(){
    for(var i=0; i<55;i++){
      this.heroSquares._results[i].init()
    }
    let code:string = 'reset'
    this.that.send(code)
  }
  exit(){
    this.that.exitFrameOut()
  }
  home(){
    this.gone()
    this.that.managerToHome()
  }
  back(){
    this.gone()
    setTimeout(() => this.that.managerToHome(), 310);
  }
}