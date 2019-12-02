import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-icon-to-button',
  templateUrl: './icon-to-button.component.html',
  styleUrls: ['./icon-to-button.component.scss']
})
export class IconToButtonComponent implements OnInit {
  @Input() icon:string
  constructor() { }

  ngOnInit() {
  }

}
