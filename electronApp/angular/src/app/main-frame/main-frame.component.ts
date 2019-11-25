import { Component, OnInit,Input } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-main-frame',
  templateUrl: './main-frame.component.html',
  styleUrls: ['./main-frame.component.scss']
})
export class MainFrameComponent implements OnInit {
  @Input() that:AppComponent
  constructor() { }

  ngOnInit() {
  }
  private start(){
    this.that.managerFrameOut()
  }
  private option(){}
  private exit(){
    this.that.exitFrameOut()
  }
}