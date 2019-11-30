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

  //处理接收的英雄数据
  setHeroInf(codes: string[]) {
    let squareId: number = Number(codes[1])
    for (let code of codes) {
      let orders = code.split('-')
      switch (orders[0]) {
        case 'skill':
          this.heroSquares._results[squareId].setHeroSkill(orders[1])
          break
      }
    }
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

  //提供给子组件的通信方式
  setHeroPlace(heroSquareId:number,hero:string){
    let code:string = 'setHeroPlace '+heroSquareId+' '+hero
    this.that.send(code)
  }
}