import { Injectable } from '@angular/core';

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
}
