import { Component, OnInit,Input } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-about-frame',
  templateUrl: './about-frame.component.html',
  styleUrls: ['./about-frame.component.scss']
})
export class AboutFrameComponent implements OnInit {
  @Input()that:AppComponent
  address:string = 'https://gitee.com/Lin-Yun/game_simulation_of_yunding.git'
  constructor() { }
  display:string = 'gone'
  ngOnInit() {
  }
  Out(){
    this.display = 'out'
  }
  Gone(){
    this.display = 'gone'
    setTimeout(() => {
      this.that.aboutFrameGone()
    }, 280);
  }
}
