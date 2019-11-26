import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PublicSrcService {
  static redNum: number = 0
  static blueNum: number = 0
  constructor() { }
  changeHeroNum(code: string[]) {
    switch (code[1]) {
      case 'redNum':
        if (!isNaN(Number(code[2]))) {
          PublicSrcService.redNum = Number(code[2])
        }
        break;
      case 'blueNum':
        if (!isNaN(Number(code[2]))) {
          PublicSrcService.blueNum = Number(code[2])
        }
        break;
    }
  }
  getBlueNum():number{
    return PublicSrcService.blueNum
  }
  getRedNum():number{
    return PublicSrcService.redNum
  }
}
