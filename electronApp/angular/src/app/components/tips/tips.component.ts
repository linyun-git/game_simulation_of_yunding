import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-tips',
  templateUrl: './tips.component.html',
  styleUrls: ['./tips.component.scss']
})
export class TipsComponent implements OnInit {
  public tipString:string ='none'
  public tipClass:string='tipBlock'
  public tipDisplay:string='none'
  constructor() { }

  ngOnInit() {
  }
  tipOut(tipString:string){
    this.tipString=tipString
    this.tipDisplay='block'
    this.tipClass='tipBlock'
  }
  tipGone(){
    setTimeout(() => this.tipString='none', 280);
    this.tipClass='tipNone'
    setTimeout(() => this.tipDisplay='none', 280);
  }
}
