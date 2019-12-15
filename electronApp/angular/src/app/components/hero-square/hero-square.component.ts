import { Component, OnInit, Input, ViewChild } from '@angular/core';

import { SelectHeroUlComponent } from '../select-hero-ul/select-hero-ul.component';
import { ManagerFrameComponent } from 'src/app/manager-frame/manager-frame.component';
import { SetHeroPieceComponent } from '../set-hero-piece/set-hero-piece.component';
import { Status } from '../../manager-frame/manager-frame.component';
import { HeroFightLogComponent } from '../hero-fight-log/hero-fight-log.component';
import { HeroLevelToStringPipe } from 'src/app/pipe/heroLevelToString/hero-level-to-string.pipe';

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
  @ViewChild(HeroFightLogComponent, { static: true }) fightLogFrame
  public hero = {
    hasHero: hasHeroStatus.hasHeroFalse,
    heroColor: '',
    heroName: '',
    heroLevel: 1,
    heroSkill: '',
    fightLog: [''],
    ability: {
      ad: 0,//攻击力
      ap: 0,//法强
      adr: 0,//物抗
      apr: 0,//法抗
      maxHP: 0,//生命值
      maxMP: 0,//法力值
      MP: 0,//技能蓝耗
      HP: 0
    }
  }

  constructor() { }
  ngOnInit() {
    this.init()
  }
  private statusEqualsWaiting() {
    if (this.that.status == Status.Waiting)
      return true
    else
      return false
  }
  private heroLevelToString(heroLevel: number): string {
    switch (heroLevel) {
      case 1:
        return 'levelOne'
      case 2:
        return 'levelTwo'
      case 3:
        return 'levelThree'
    }
  }
  squareClass(): string[] {
    console.log('class');

    let Class: string[] = []
    if (this.statusEqualsWaiting()) {
      Class.push('pointer')
      Class.push(this.heroSquareColor)
      if (this.hero.hasHero == hasHeroStatus.hasHeroTrue) {
        Class.push('textnone')
        Class.push(this.heroLevelToString(this.hero.heroLevel))
      }
      else {
        Class.push('textblock')
      }
    }
    else {
      Class.push('textnone')
      if (this.hero.hasHero == hasHeroStatus.hasHeroTrue) {
        Class.push(this.hero.heroColor)
        Class.push(this.heroLevelToString(this.hero.heroLevel))
      }
      else {
        Class.push('borderLight')
      }
    }
    return Class
  }
  //事件
  //单击事件
  click() {
    if (this.statusEqualsWaiting()) {
      this.toSelectHero()
    }
    else {
      this.viewFightLog()
    }
  }
  //右键事件
  contextmenu() {
    if (this.statusEqualsWaiting())
      this.checkHeroInf()
  }


  //执行
  viewFightLog() {
    if (this.hero.hasHero == hasHeroStatus.hasHeroTrue) {
      this.fightLogFrame.block()
    }
  }
  toSelectHero() {
    this.selectHeroFrame.selectHero()
  }
  checkHeroInf() {
    if (this.hero.hasHero == hasHeroStatus.hasHeroTrue)
      this.setHeroFrame.open()
  }

  //设置英雄
  setHeroLevel(heroLevel: number) {
    this.hero.heroLevel = heroLevel
  }
  changeHeroLevel() {
    this.that.changeHeroLevel(this.heroSquareId)
  }
  setHero(hero: string) {
    this.hero.heroName = hero
    this.hero.hasHero = hasHeroStatus.hasHeroTrue
    this.hero.heroColor = this.heroSquareColor
    this.that.setHeroPlace(this.heroSquareId, hero)
  }
  init(heroAbilities?: string[]) {
    if (heroAbilities == undefined) {
      this.hero.hasHero = hasHeroStatus.hasHeroFalse
      this.hero.heroName = ''
      this.hero.heroLevel = 1
      this.hero.heroSkill = ''
      this.hero.ability.ad = 0
      this.hero.ability.ap = 0
      this.hero.ability.adr = 0
      this.hero.ability.apr = 0
      this.hero.ability.HP = 0
      this.hero.ability.MP = 0
      this.hero.ability.maxMP = 0
      this.hero.ability.maxHP = 0
      this.hero.fightLog = []
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
          case 'maxMP':
            this.hero.ability.maxMP = Number(order[1])
            break
          case 'maxHP':
            this.hero.ability.maxHP = Number(order[1])
            break
          case 'level':
            this.hero.heroLevel = Number(order[1])
            break;
        }
      }
    }
  }
}
export enum hasHeroStatus { hasHeroFalse, hasHeroTrue }