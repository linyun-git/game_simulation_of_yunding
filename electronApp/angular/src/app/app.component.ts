import { Component, ViewChild, OnInit } from '@angular/core';
import { ExitFrameComponent } from './exit-frame/exit-frame.component';
import { ManagerFrameComponent } from './manager-frame/manager-frame.component';
import { PublicSrcService } from './services/public-src.service';
let pubsrc = new PublicSrcService
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  @ViewChild('exitFrame', { static: true }) private exitFrame: ExitFrameComponent
  @ViewChild('managerFrame', { static: true }) private managerFrame: ManagerFrameComponent
  title = 'angular';
  protected frameZIndex: string[] = ['0', '2', '1']
  constructor() { }
  ngOnInit(): void {
    this.connect()
  }
  //切换界面
  exitFrameOut() {
    this.frameZIndex[0] = '5'
    this.exitFrame.exitFrameOut()
  }
  exitFrameGone() {
    setTimeout(() => this.frameZIndex[0] = '0', 290);
  }
  managerFrameOut() {
    this.frameZIndex[2] = '2'
    this.frameZIndex[1] = '1'
    this.managerFrame.managerFrameOut()
  }
  managerToHome() {
    this.frameZIndex[1] = '2'
    this.frameZIndex[2] = '1'
  }

  //WebSocket通信
  private ws: WebSocket
  connect() {
    let that = this
    this.ws = new WebSocket('ws://127.0.0.1:4430')
    this.ws.onopen = function (e) {
      that.ws.send('这里是web端')
      that.ws.send('init')
    }
    this.ws.onmessage = function (e) {
      that.receive(e.data)
    }
    this.ws.onclose = function (e) {
      console.log('断开连接')
    }
  }
  receive(code: string) {
    let codes: string[] = code.split(' ')
    switch (codes[0]) {
      case 'init':
        codes.shift()
        pubsrc.setHeros(codes)
        break
      case 'setHeroNum':
        this.managerFrame.setHeroNum(codes)
        break
      case 'setHeroInf':
        this.managerFrame.setHeroInf(codes)
        break
      case 'setHeroLevel':
        this.managerFrame.setHeroLevel(codes)
        break
      case 'hero':
        pubsrc.addHero(codes[1])
        break
      case 'setInit':
        this.managerFrame.setInit(codes)
        break
      case 'error':
        alert(codes[1])
        break
    }
  }
  send(mes: string) {
    if (this.ws) {
      this.ws.send(mes)
    }
  }
}