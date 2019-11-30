import { Component, OnInit,Input,ViewChild} from '@angular/core';

import { SelectHeroUlComponent } from '../select-hero-ul/select-hero-ul.component';
import { ManagerFrameComponent } from 'src/app/manager-frame/manager-frame.component';

@Component({
  selector: 'app-hero-square',
  templateUrl: './hero-square.component.html',
  styleUrls: ['./hero-square.component.scss']
})
export class HeroSquareComponent implements OnInit{
  @Input() heroSquareColor:string
  @Input() heroSquareId:number
  @Input() that:ManagerFrameComponent
  @ViewChild('selectHero',{static:true}) selectHeroFrame:SelectHeroUlComponent
  constructor() { }
  ngOnInit() {
    this.hero.hasHero='hasHeroFalse'
    this.hero.heroColor=this.heroSquareColor
  }
  toSelectHero(){
    this.selectHeroFrame.selectHero()
  }
  setHero(hero:string){
    this.hero.heroName=hero
    this.hero.hasHero='hasHeroTrue'
    this.that.setHeroPlace(this.heroSquareId,hero)
  }
  setHeroSkill(skill:string){
    this.hero.heroSkill = skill
    alert('将id:'+this.heroSquareId+'的skill'+'设置为：'+this.hero.heroSkill)
  }
  alert(){
    alert('一个alert')
  }
  protected hero = {
  hasHero:'',
  heroColor:'',
  heroId:0,
  heroName:'',
  heroLevel:3,
  heroSkill:''
  }
}