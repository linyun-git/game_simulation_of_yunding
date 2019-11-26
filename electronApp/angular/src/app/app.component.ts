import { Component,ViewChild,OnInit } from '@angular/core';
import { ExitFrameComponent } from './exit-frame/exit-frame.component';
import { WebSocketService } from './services/web-socket.service';
import { ManagerFrameComponent } from './manager-frame/manager-frame.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  implements OnInit{
  @ViewChild('exitFrame',{static:true}) private exitFrame:ExitFrameComponent
  @ViewChild('managerFrame',{static:true}) private managerFrame:ManagerFrameComponent
  title = 'angular';
  protected frameZIndex:string[]=['0','2','1']


  constructor(public ws:WebSocketService) { }
  ngOnInit(): void {
    this.ws.connect()
  }


  exitFrameOut(){
    this.frameZIndex[0]='5'
    this.exitFrame.exitFrameOut()
  }
  exitFrameGone(){
    setTimeout(() => this.frameZIndex[0]='0', 290);
  }
  managerFrameOut(){
    this.frameZIndex[2]='2'
    this.frameZIndex[1]='1'
    this.managerFrame.managerFrameOut()
  }
}

//英雄类
export class hero{
  public hasHero:string=''
  public heroColor:string=''
  public heroId:number
  public heroName:string=''
  public heroLevel:number=3
  public heroSkill:string=''
  constructor(){
  }
}