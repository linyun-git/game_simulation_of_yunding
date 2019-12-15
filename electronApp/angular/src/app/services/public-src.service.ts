import { Injectable } from '@angular/core';
import { HeroSquareComponent } from '../components/hero-square/hero-square.component';

@Injectable({
  providedIn: 'root'
})
export class PublicSrcService {
  public static heros:string[] = []
  constructor() { }
  getHeros():string[]{
    return PublicSrcService.heros
  }
  setHeros(heros:string[]){
    PublicSrcService.heros = heros
  }
  addHero(hero:string){
    PublicSrcService.heros.push(hero)
  }
}
