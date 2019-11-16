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
  public hero:string[]=["vn","ksd"]
  public heroSelectOn:HeroHeadPhotoComponent
  public heroBorder:any[]=[{"hero":'vn',"place":1}]

  public heroSelectFrameDisplay:string='none'
  public mainZIndex='2'
  public exitZIndex='0'
  public heroManagerZIndex='0'
  title = 'angular';
  public exitFrameAct='go'
  public heroBlue='blue'
  public heroRed='red'
  public redNum:number=0
  public blueNum:number=0
  public heroManagerAct=''
  public heroSquare:HeroSquareComponent

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
  }
  selectHeroOk(){
    this.heroSquare.selectHero(this.heroSelectOn.hero)
    this.heroSelectFrameDisplay='none'
  }
  optionOut(){
    this.optionFrame.optionOut()
  }

}