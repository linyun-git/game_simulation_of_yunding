import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-hero-square',
  templateUrl: './hero-square.component.html',
  styleUrls: ['./hero-square.component.scss']
})
export class HeroSquareComponent implements OnInit {
  @Input() heroSquareColor:string
  public heroOn:string
  public hasHero:string='hasHeroFalse'
  constructor() { }

  ngOnInit() {
  }
  atestau(){
    
  }
  selectHero(hero:string){
    if(hero!=undefined){
      this.hasHero='hasHeroTrue'
      this.heroOn='assets/headPhoto/'+hero+'.gif'
    }
    else{
      this.heroOn=''
      this.hasHero='hasHeroFalse'
    }
  }
}
