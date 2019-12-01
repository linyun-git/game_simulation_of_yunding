import { Component, OnInit,Input } from '@angular/core';
import { HeroSquareComponent } from '../hero-square/hero-square.component';

@Component({
  selector: 'app-set-hero-piece',
  templateUrl: './set-hero-piece.component.html',
  styleUrls: ['./set-hero-piece.component.scss']
})
export class SetHeroPieceComponent implements OnInit {
  @Input() that:HeroSquareComponent
  readCont: string = 'readCont1'
  display: string = 'none'
  constructor() { }

  ngOnInit() {
  }
  public open() {
    this.display = 'block'
  }
  private close() {
    this.display = 'none'
  }
  setHeroLevel() {
    this.that.changeHeroLevel()
  }
  readCont1() {
    this.readCont = 'readCont1'
  }
  readCont2() {
    this.readCont = 'readCont2'
  }
  readCont3() {
    this.readCont = 'readCont3'
  }
}
