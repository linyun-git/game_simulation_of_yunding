import { Component, OnInit, Input, ViewChild } from '@angular/core';

import { SelectHeroUlComponent } from '../select-hero-ul/select-hero-ul.component';
import { ManagerFrameComponent } from 'src/app/manager-frame/manager-frame.component';
import { SetHeroPieceComponent } from '../set-hero-piece/set-hero-piece.component';

@Component({
  selector: 'app-hero-square',
  templateUrl: './hero-square.component.html',
  styleUrls: ['./hero-square.component.scss']
})
export class HeroSquareComponent implements OnInit {
  @Input() heroSquareColor: string
  @Input() heroSquareId: number
  @Input() that: ManagerFrameComponent
  @ViewChild(SelectHeroUlComponent, { static: true }) selectHeroFrame
  @ViewChild(SetHeroPieceComponent, { static: true }) setHeroFrame
  protected hero = {
    hasHero: hasHeroStatus.hasHeroFalse,
    heroColor: '',
    heroId: 0,
    heroName: '',
    heroLevel: 1,
    heroSkill: '',
    ability: {
      ad: 0,//攻击力
      ap: 0,//法强
      adr: 0,//物抗
      apr: 0,//法抗
      HP: 0,//生命值
      MP: 0,//法力值
      skillMp: 0//技能蓝耗
    }
  }

  constructor() { }
  ngOnInit() {
    this.init()
  }

  //事件
  toSelectHero() {
    this.selectHeroFrame.selectHero()
  }
  right() {
    if (this.hero.hasHero == hasHeroStatus.hasHeroTrue)
      this.setHeroFrame.open()
  }
  changeHeroLevel() {
    this.that.changeHeroLevel(this.heroSquareId)
  }

  //设置英雄
  setHeroLevel(heroLevel: number) {
    this.hero.heroLevel = heroLevel
  }
  setHero(hero: string) {
    this.hero.heroName = hero
    this.hero.hasHero = hasHeroStatus.hasHeroTrue
    this.that.setHeroPlace(this.heroSquareId, hero)
  }
  init(heroAbilities?: string[]) {
    if (heroAbilities == undefined) {
      this.hero.hasHero = hasHeroStatus.hasHeroFalse
      this.hero.heroColor = this.heroSquareColor
      this.hero.heroId = 0
      this.hero.heroName = ''
      this.hero.heroLevel = 1
      this.hero.heroSkill = ''
      this.hero.ability.ad = 0
      this.hero.ability.ap = 0
      this.hero.ability.adr = 0
      this.hero.ability.apr = 0
      this.hero.ability.HP = 0
      this.hero.ability.MP = 0
      this.hero.ability.skillMp = 0
    }
    else {
      for (let heroAbility of heroAbilities) {
        let order = heroAbility.split('-')
        switch (order[0]) {
          case 'skill':
            this.hero.heroSkill = order[1]
            break
          case 'ad':
            this.hero.ability.ad = Number(order[1])
            break
          case 'ap':
            this.hero.ability.ap = Number(order[1])
            break
          case 'adr':
            this.hero.ability.adr = Number(order[1])
            break
          case 'apr':
            this.hero.ability.apr = Number(order[1])
            break
          case 'HP':
            this.hero.ability.HP = Number(order[1])
            break
          case 'MP':
            this.hero.ability.MP = Number(order[1])
            break
          case 'skillMp':
            this.hero.ability.skillMp = Number(order[1])
            break
        }
      }
    }
  }
}
export enum hasHeroStatus{hasHeroFalse,hasHeroTrue}