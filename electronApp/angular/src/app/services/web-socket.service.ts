import { Injectable } from '@angular/core';
import { webSocket } from 'rxjs/webSocket';
import { PublicSrcService } from '../services/public-src.service';
import { WSAEACCES } from 'constants';

@Injectable({
  providedIn: 'root'
})
export class WebSocketService {
  private static ws: WebSocket
  private static webSocketAdd: string = 'ws://127.0.0.1:4300'
  private static heroNames: string[]
  constructor(public publicSrc: PublicSrcService) { }
  connect() {
    let that = this
    let wsAdd = WebSocketService.webSocketAdd
    WebSocketService.ws = new WebSocket(wsAdd)
    WebSocketService.ws.onopen = function (e) {
      WebSocketService.ws.send('这里是web端')
    }
    WebSocketService.ws.onmessage = function (e) {
      let code: string[] = e.data.split(' ')
      switch (code[0]) {
        case 'setHeroNum':
          that.publicSrc.changeHeroNum(code)
          break
      }
    }
  }
  setHeroPlace(heroSquareId: number, heroName: string) {
    let ws = WebSocketService.ws
    let code: string = 'setHero heroPlace ' + heroSquareId + ' ' + heroName
    ws.send(code)
  }
}