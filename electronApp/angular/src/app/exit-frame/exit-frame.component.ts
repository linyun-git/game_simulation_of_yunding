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
    this.that.send('exit')
    this.that.exitFrameGone()
    this.exitFrameAct='go'
    setTimeout(() => this.that.send('bye'), 200);
  }
  exitFrameOut(){
    this.exitFrameAct='come'
  }
}