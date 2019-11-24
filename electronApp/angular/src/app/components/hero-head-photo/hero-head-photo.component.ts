import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-hero-head-photo',
  templateUrl: './hero-head-photo.component.html',
  styleUrls: ['./hero-head-photo.component.scss']
})
export class HeroHeadPhotoComponent implements OnInit {
  @Input() hero:string
  public heroSelect:string=''
  constructor() { }

  ngOnInit() {
  }
  public selectOn(){
    this.heroSelect='selectOn'
  }
  public selectOff(){
    this.heroSelect=''
  }
}
