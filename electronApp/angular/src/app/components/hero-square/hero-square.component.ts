import { Component, OnInit,Input,ViewChild} from '@angular/core';

import { SelectHeroUlComponent } from '../select-hero-ul/select-hero-ul.component';
import { ManagerFrameComponent } from 'src/app/manager-frame/manager-frame.component';
import { SetHeroPieceComponent } from '../set-hero-piece/set-hero-piece.component';

@Component({
  selector: 'app-hero-square',
  templateUrl: './hero-square.component.html',
  styleUrls: ['./hero-square.component.scss']
})
export class HeroSquareComponent implements OnInit{
  @Input() heroSquareColor:string
  @Input() heroSquareId:number
  @Input() that:ManagerFrameComponent
  @ViewChild(SelectHeroUlComponent,{static:true}) selectHeroFrame
  @ViewChild(SetHeroPieceComponent,{static:true}) setHeroFrame
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
  }
  right(){
    if(this.hero.hasHero == 'hasHeroTrue')
    this.setHeroFrame.open()
  }
  changeHeroLevel() {
    this.that.changeHeroLevel(this.heroSquareId)
  }
  setHeroLevel(heroLevel:number){
    this.hero.heroLevel = heroLevel
  }
  protected hero = {
  hasHero:'',
  heroColor:'',
  heroId:0,
  heroName:'',
  heroLevel:1,
  heroSkill:'',
  ability:{
    ad:0,//攻击力
    ap:0,//法强
    adr:0,//物抗
    apr:0,//法抗
    HP:0,//生命值
    MP:0,//法力值
    skillMp:0//技能蓝耗
  }
  }
}