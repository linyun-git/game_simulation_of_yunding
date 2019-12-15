import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tips',
  templateUrl: './tips.component.html',
  styleUrls: ['./tips.component.scss']
})
export class TipsComponent implements OnInit {
  tip:string
  tipClass:string
  constructor() { }

  ngOnInit() {
  }
  giveTip(tip:string){
    this.tip = tip
    this.tipClass = 'act'
    setTimeout(() => {
      this.tipClass = 'notAct'
    }, 3000);
  }
}
