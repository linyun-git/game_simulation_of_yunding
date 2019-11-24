import { Component,ViewChild } from '@angular/core';
import { ExitFrameComponent } from './exit-frame/exit-frame.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @ViewChild('exitFrame',{static:true}) private exitFrame:ExitFrameComponent
  title = 'angular';

  protected frameZIndex:string[]=['0','1','2']
  exitFrameOut(){
    this.frameZIndex[0]='5'
    this.exitFrame.exitFrameOut()
  }
  exitFrameGone(){
    setTimeout(() => this.frameZIndex[0]='0', 290);
  }
}
export class hero{
  public hasHero:string=''
  public heroColor:string=''
  public heroId:number
  public heroName:string=''
  public heroLevel:number
  public heroSkill:string=''
  constructor(){
  }
}