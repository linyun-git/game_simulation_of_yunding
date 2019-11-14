import { Component,ViewChild } from '@angular/core';
import { TipsComponent } from './components/tips/tips.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @ViewChild('tip',{static:true}) tip:TipsComponent

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
}