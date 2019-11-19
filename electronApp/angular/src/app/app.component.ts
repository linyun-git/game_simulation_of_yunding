import { Component,ViewChild,ViewChildren } from '@angular/core';
import { TipsComponent } from './components/tips/tips.component';
import { HeroSquareComponent } from './components/hero-square/hero-square.component';
import { HeroHeadPhotoComponent } from './components/hero-head-photo/hero-head-photo.component';
import { OptionComponent } from './components/option/option.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public heroName:string
  @ViewChild('tip',{static:true}) tip:TipsComponent
  @ViewChild('option',{static:true}) optionFrame:OptionComponent
  @ViewChildren(HeroHeadPhotoComponent) heroHeads
  @ViewChildren(HeroSquareComponent) heroSquares 

  public menuContent='menu'

  public hero:string[]=["vn","ksd"]
  public heroSelectOn:HeroHeadPhotoComponent
  public heroBorder:any[]=[{"hero":'vn',"place":1}]

  public heroSelectFrameDisplay:string='block'
  public mainZIndex='0'
  public exitZIndex='0'
  public heroManagerZIndex='2'
  title = 'angular';
  public exitFrameAct='go'
  public heroBlue='blue'
  public heroRed='red'
  public heroManagerAct=''
  public heroSquare:HeroSquareComponent

  public heroNum:number[]=[0,0]
  public heroColor:number

  constructor() { }
  ngOnInit() {
  }
  exitOk(){
    
  }
  exitFrameOut(){
    this.exitZIndex='6'
    this.exitFrameAct='come'
  }
  exitFrameGone(){
    setTimeout(() => this.exitZIndex='0', 250);
    this.exitFrameAct='go'
  }
  start(){
    this.mainZIndex='1'
    this.heroManagerZIndex='2'
    this.heroManagerAct='heroManagerAct'
    setTimeout(() => this.heroManagerAct='', 1200);
    setTimeout(() => this.tip.tipOut('在这里管理您的阵容'), 1000);
  }
  menu(){
    this.mainZIndex='2'
    this.heroManagerZIndex='1'
  }
  setHero(heroSquare:HeroSquareComponent){
    this.heroSquare=heroSquare
  }
  selectHero(hero:number){
    if(this.heroSelectOn!=undefined)
      this.heroSelectOn.selectOff()
    this.heroHeads._results[hero].selectOn()
    this.heroSelectOn=this.heroHeads._results[hero]
  }

  selectHeroSquare(heroSquare:number){
    this.heroSelectFrameDisplay='block'
    this.heroSquare=this.heroSquares._results[heroSquare]
    if(heroSquare<=27)
      this.heroColor=0
    else
      this.heroColor=1
  }
  selectHeroOk(){
    if(this.heroSelectOn!=undefined){
      this.heroSelectOn.selectOff()
      if(this.heroNum[this.heroColor]<10){
        this.heroNum[this.heroColor]++
        this.heroSquare.selectHero(this.heroSelectOn.hero)
      }
    }
    this.heroSelectFrameDisplay='none'
  }
  selectHeroNo(){
    this.heroSelectFrameDisplay='none'
    if(this.heroSelectOn!=undefined)
      this.heroSelectOn.selectOff()
  }
  optionOut(){
    this.optionFrame.optionOut()
  }

}