import { Component, OnInit, ViewChild, AfterViewChecked, ElementRef, Input } from '@angular/core';
import { HeroSquareComponent } from '../hero-square/hero-square.component';

@Component({
  selector: 'app-hero-fight-log',
  templateUrl: './hero-fight-log.component.html',
  styleUrls: ['./hero-fight-log.component.scss']
})
export class HeroFightLogComponent implements OnInit {
  @Input() that: HeroSquareComponent
  @ViewChild('scroll', { static: true }) private logScroll: ElementRef;
  //日志自动滚动到最下方
  scrollToBottom() {
    try {
      this.logScroll.nativeElement.scrollTop = this.logScroll.nativeElement.scrollHeight;
    } catch (err) { }
  }
  read: string = '欧拉'
  log: string[] = []
  display: string = 'none'
  block() {
    this.init()
    this.display = 'block'
  }
  init() {
    this.display = 'none'
    this.top = 250
    this.left = 475
  }
  constructor() { }
  ngOnInit() {
    this.log = this.that.hero.oulaLog
  }
  switchLog() {
    switch (this.read) {
      case '欧拉':
        this.read = '木哒'
        this.log = this.that.hero.mudaLog
        break
      case '木哒':
        this.read = '欧拉'
        this.log = this.that.hero.oulaLog
        break
    }
  }
  HPpoint() {
    return this.that.hero.ability.HP / this.that.hero.ability.maxHP
  }
  MPpoint() {
    if(this.that.hero.ability.maxMP==0){
      return 0
    }
    return this.that.hero.ability.MP / this.that.hero.ability.maxMP
  }
  //允许移动
  status: string = 'static'
  top: number = 250
  left: number = 475
  private x: number = this.left
  private y: number = this.top
  private X: number
  private Y: number
  mousedown(e: MouseEvent) {
    this.x = this.left
    this.y = this.top
    this.X = e.clientX
    this.Y = e.clientY
    this.status = 'moving'
  }
  mouseup() {
    this.status = 'static'
  }
  mousemove(e: MouseEvent) {
    if (this.status == 'moving') {
      this.move(this.x + e.clientX - this.X, this.y + e.clientY - this.Y)
    }
  }
  move(x: number, y: number) {
    if (y > 20 && y < 520) {
      this.top = y
    }
    else if (y <= 20) {
      this.top = 21
    }
    else {
      this.top = 519
    }
    if (x > 0 && x < 950) {
      this.left = x
    }
    else if (x <= 0) {
      this.left = 0
    }
    else {
      this.left = 949
    }
  }
}