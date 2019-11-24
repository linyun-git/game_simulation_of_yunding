import { Component, OnInit,Input } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-exit-frame',
  templateUrl: './exit-frame.component.html',
  styleUrls: ['./exit-frame.component.scss']
})
export class ExitFrameComponent implements OnInit {
  @Input() that:AppComponent
  protected exitFrameAct=''
  constructor() { }

  ngOnInit() {
  }
  protected cancel(){
    this.that.exitFrameGone()
    this.exitFrameAct='go'
  }
  protected ok(){
  }
  exitFrameOut(){
    this.exitFrameAct='come'
  }
}