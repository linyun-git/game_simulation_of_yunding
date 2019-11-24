import { Component, OnInit,ViewChild } from '@angular/core';
import { TipsComponent } from '../tips/tips.component';
import { webSocket } from 'rxjs/webSocket';

@Component({
  selector: 'app-option',
  templateUrl: './option.component.html',
  styleUrls: ['./option.component.scss']
})
export class OptionComponent implements OnInit {
  public tipString:string ='none'
  public tipClass:string='tipBlock'
  public tipDisplay:string='none'
  public connected:string='no'
  ws:WebSocket
  @ViewChild('tip',{static:true}) tip:TipsComponent
  constructor() { }

  ngOnInit() {
  }
  optionOut(){
    this.tipDisplay='block'
    this.tipClass='tipBlock'
  }
  optionGone(){
    setTimeout(() => this.tipString='none', 280);
    this.tipClass='tipNone'
    setTimeout(() => this.tipDisplay='none', 280);
  }
  connect(){
    const ws=new WebSocket("ws://127.0.0.1:1818");
    let priTip=this.tip
    ws.onopen=function(e){
      ws.send('这里是web端');
    }
    ws.onmessage=function(e){
      alert(e.data)
      priTip.tipOut(e.data)
    }
  }
  send(){
    if(this.ws){
      this.ws.send('')
      this.ws.close()
    }
  }
  
}
