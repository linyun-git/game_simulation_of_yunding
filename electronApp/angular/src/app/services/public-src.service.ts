import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PublicSrcService {
  static redNum: number = 1
  static blueNum: number = 2
  constructor() { }
  changeHeroNum(code: string[]) {
    switch (code[1]) {
      case 'redNum':
        if (isNaN(Number(code[2]))) {
          PublicSrcService.redNum = Number(code[2])
        }
        break;
      case 'blueNum':
        if (isNaN(Number(code[2]))) {
          PublicSrcService.blueNum = Number(code[2])
        }
        break;
    }
  }
}
