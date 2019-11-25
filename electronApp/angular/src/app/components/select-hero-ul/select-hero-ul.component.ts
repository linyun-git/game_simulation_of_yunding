import { Component, OnInit,Input } from '@angular/core';
import { HeroSquareComponent } from '../hero-square/hero-square.component';

@Component({
  selector: 'app-select-hero-ul',
  templateUrl: './select-hero-ul.component.html',
  styleUrls: ['./select-hero-ul.component.scss']
})
export class SelectHeroUlComponent implements OnInit {
  @Input() that:HeroSquareComponent
  public heros:string[] = ['阿兹尔','艾翁','黛安娜','劫','拉克丝','乐芙兰','雷克顿','娜美','千珏','辛德拉']
  protected display:string='none'
  constructor() { }

  ngOnInit() {
  }
  private cancel(){
    this.display='none'
  }
  selectHero(){
    this.display='block'
  }
}
