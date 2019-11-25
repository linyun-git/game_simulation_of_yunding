import { Component, OnInit,Input } from '@angular/core';
import { HeroSquareComponent } from '../hero-square/hero-square.component';

@Component({
  selector: 'app-select-hero-li',
  templateUrl: './select-hero-li.component.html',
  styleUrls: ['./select-hero-li.component.scss']
})
export class SelectHeroLiComponent implements OnInit {
  @Input() that:HeroSquareComponent
  @Input() hero:string
  constructor() { }

  ngOnInit() {
  }
  selectHero(){
    this.that.setHero(this.hero)
  }
}
