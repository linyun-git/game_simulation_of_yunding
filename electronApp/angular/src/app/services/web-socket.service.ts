import { Injectable } from '@angular/core';
import { webSocket } from 'rxjs/webSocket';

@Injectable({
  providedIn: 'root'
})
export class WebSocketService {
  private static ws:WebSocket
  private static webSocketAdd:string='ws://127.0.0.1:4300'
  private static heroNames:string[]
  constructor() { }
  connect(){
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
      let text:string[] = message.split(' ')
      alert(text)
    }
  }
}