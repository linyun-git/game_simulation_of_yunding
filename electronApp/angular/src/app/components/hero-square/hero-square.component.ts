import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-hero-square',
  templateUrl: './hero-square.component.html',
  styleUrls: ['./hero-square.component.scss']
})
export class HeroSquareComponent implements OnInit {
  @Input() heroSquareColor:string
  constructor() { }

  ngOnInit() {
  }

}
