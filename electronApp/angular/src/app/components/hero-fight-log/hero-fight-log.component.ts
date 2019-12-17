import { Component, OnInit, ViewChild, AfterViewChecked, ElementRef,Input } from '@angular/core';
import { HeroSquareComponent } from '../hero-square/hero-square.component';

@Component({
  selector: 'app-hero-fight-log',
  templateUrl: './hero-fight-log.component.html',
  styleUrls: ['./hero-fight-log.component.scss']
})
export class HeroFightLogComponent implements OnInit, AfterViewChecked {
  @Input() that:HeroSquareComponent
  @ViewChild('scroll', { static: true }) private logScroll: ElementRef;
  //日志自动滚动到最下方
  ngAfterViewChecked(): void {
    this.scrollToBottom()
  }
  scrollToBottom(){
    try {
      this.logScroll.nativeElement.scrollTop = this.logScroll.nativeElement.scrollHeight;
    } catch (err) { }
  }
  hasMove:boolean = false
  display:string = 'none'
  HP: number = 60
  maxHP: number = 100
  MP: number = 10
  maxMP: number = 100
  heroName: string = '劫'
  block(){
    this.display = 'block'
  }
  none(){
    this.display = 'none'
  }
  log: string[] = []
  constructor() { }
  ngOnInit() {
  }
  HPpoint(){
    return this.that.hero.ability.HP/this.that.hero.ability.maxHP
  }
  MPpoint(){
    return this.that.hero.ability.MP/this.that.hero.ability.maxMP
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
    if(this.hasMove){
      this.hasMove = false
    }
    else{
      this.none()
    }
  }
  mousemove(e: MouseEvent) {
    this.hasMove = true
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