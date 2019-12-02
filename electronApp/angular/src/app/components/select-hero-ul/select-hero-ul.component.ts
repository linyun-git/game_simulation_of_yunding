import { Component, OnInit,Input } from '@angular/core';
import { HeroSquareComponent } from '../hero-square/hero-square.component';
import { PublicSrcService } from 'src/app/services/public-src.service';
@Component({
  selector: 'app-select-hero-ul',
  templateUrl: './select-hero-ul.component.html',
  styleUrls: ['./select-hero-ul.component.scss']
})
export class SelectHeroUlComponent implements OnInit {
  @Input() that:HeroSquareComponent
  protected display:string='none'
  constructor(public pubsrc:PublicSrcService) { }

  ngOnInit() {
  }
  private cancel(){
    this.display='none'
  }
  selectHero(){
    this.display='block'
  }
}
