import { Component, OnInit,Input,ViewChild} from '@angular/core';
import { hero } from 'src/app/app.component';

import { WebSocketService } from '../../services/web-socket.service';
import { SelectHeroUlComponent } from '../select-hero-ul/select-hero-ul.component';

@Component({
  selector: 'app-hero-square',
  templateUrl: './hero-square.component.html',
  styleUrls: ['./hero-square.component.scss']
})
export class HeroSquareComponent implements OnInit{
  @Input() heroSquareColor:string
  @ViewChild('selectHero',{static:true}) selectHero:SelectHeroUlComponent
  public hero = new hero
  constructor(public webSocket:WebSocketService) { }
  
  ngOnInit() {
    this.hero.hasHero='hasHeroFalse'
    this.hero.heroColor=this.heroSquareColor
  }
  heroTrue(){
    this.selectHero.selectHero()
  }
}