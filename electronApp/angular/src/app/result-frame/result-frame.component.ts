import { Component, OnInit,Input } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-result-frame',
  templateUrl: './result-frame.component.html',
  styleUrls: ['./result-frame.component.scss']
})
export class ResultFrameComponent implements OnInit {
  @Input() that:AppComponent
  input: string
  hero: string
  output: number

  display:string
  constructor() { }
  color: string
  title: string
  ngOnInit() {
    this.reset()
  }
  reset(){
    this.display = 'gone'
    this.color = 'green'
    this.hero = '未知'
  }
  result(result:string[]) {
    this.input = result[0]
    this.hero = result[1]
    this.output = Number(result[2])
    this.init()
    this.Out()
  }
  init() {
    switch (this.input) {
      case 'red':
        this.title = '红方胜利'
        this.color = 'red'
        break
      case 'blue':
        this.title = '蓝方胜利'
        this.color = 'blue'
        break
      default:
        this.title = '平局'
        this.color = 'green'
        break
    }
  }
  Gone(){
    this.display = 'gone'
    setTimeout(() => {
      this.that.resultFrameGone()
    }, 280);
    setTimeout(() => {
      this.reset()
    }, 280);
    setTimeout(() => {
      this.that.end()
    }, 280);
  }
  Out(){
    this.display = 'out'
  }
}
