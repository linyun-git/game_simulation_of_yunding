import { Component,ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public exitZIndex='0'
  title = 'angular';
  public exitFrameAct='go'

  constructor() { }
  ngOnInit() {
  }
  
  exitFrameOut(){
    this.exitZIndex='6'
    this.exitFrameAct='come'
  }
  exitFrameGone(){
    setTimeout(() => this.exitZIndex='0', 250);
    this.exitFrameAct='go'
  }
}