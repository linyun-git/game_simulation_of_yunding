import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manager-frame',
  templateUrl: './manager-frame.component.html',
  styleUrls: ['./manager-frame.component.scss']
})
export class ManagerFrameComponent implements OnInit {
  protected heroBlue='blue'
  protected heroRed='red'
  protected heroNum:number[]=[0,0]
  constructor() { }

  ngOnInit() {
  }

}
