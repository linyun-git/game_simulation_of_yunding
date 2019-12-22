import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-result-frame',
  templateUrl: './result-frame.component.html',
  styleUrls: ['./result-frame.component.scss']
})
export class ResultFrameComponent implements OnInit {
  input: string
  hero: string
  output: number

  display:string
  constructor() { }
  color: string
  title: string
  ngOnInit() {
    this.display = 'gone'
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
  }
  Out(){
    this.display = 'out'
  }
}
