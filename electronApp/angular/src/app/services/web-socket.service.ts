import { Injectable } from '@angular/core';
import { webSocket } from 'rxjs/webSocket';
import { PublicSrcService } from '../services/public-src.service';

@Injectable({
  providedIn: 'root'
})
export class WebSocketService {
  private static ws:WebSocket
  private static webSocketAdd:string='ws://127.0.0.1:4300'
  private static heroNames:string[]
  constructor(public publicSrc:PublicSrcService) { }
  connect(){
    let that=this
    let ws=WebSocketService.ws
    let wsAdd=WebSocketService.webSocketAdd
    ws = new WebSocket(wsAdd)
    ws.onopen=function(e){
      ws.send('这里是web端')
    }
    ws.onmessage=function(e){
      let message:string = e.data
      // if(isNaN(Number(message))){
      //   alert('字符串：'+message)
      // }
      // else{
      //   alert('数字'+Number(message))
      // }
      let code:string[] = message.split(' ')
      switch(code[0]){
        case 'setHeroNum':
          that.publicSrc.changeHeroNum(code)
          break
      }
    }
  }
}