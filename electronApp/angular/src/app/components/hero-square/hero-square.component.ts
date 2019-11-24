import { Component, OnInit,Input} from '@angular/core';
import { hero } from 'src/app/app.component';

import { WebSocketService } from '../../services/web-socket.service';

@Component({
  selector: 'app-hero-square',
  templateUrl: './hero-square.component.html',
  styleUrls: ['./hero-square.component.scss']
})
export class HeroSquareComponent implements OnInit{
  @Input() heroSquareColor:string
  public hero = new hero
  constructor(public webSocket:WebSocketService) { }
  
  ngOnInit() {
    this.hero.hasHero='hasHeroFalse'
    this.hero.heroColor=this.heroSquareColor
  }
  heroTrue(){
    let check:boolean
    if(check||check==undefined){
      this.hero.hasHero='hasHeroTrue'
      check=false
    }
    else{
      this.hero.hasHero='hasHeroFalse'
      check=true
    }
    this.webSocket.connect()
  }
}