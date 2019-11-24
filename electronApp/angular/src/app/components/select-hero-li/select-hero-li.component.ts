import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-select-hero-li',
  templateUrl: './select-hero-li.component.html',
  styleUrls: ['./select-hero-li.component.scss']
})
export class SelectHeroLiComponent implements OnInit {
  @Input() hero:string
  constructor() { }

  ngOnInit() {
  }
  tanchu(){
    alert('点击了小li')
  }
}
