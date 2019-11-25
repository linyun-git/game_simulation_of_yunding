import { Component, OnInit } from '@angular/core';
import { PublicSrcService } from '../services/public-src.service';

@Component({
  selector: 'app-manager-frame',
  templateUrl: './manager-frame.component.html',
  styleUrls: ['./manager-frame.component.scss']
})
export class ManagerFrameComponent implements OnInit {
  protected heroBlue='blue'
  protected heroRed='red'
  protected heroNum:number[]=[0,0]
  protected redNum:number = PublicSrcService.redNum
  protected blueNum:number = PublicSrcService.blueNum
  protected heroManagerAct:string=''
  constructor() { }

  ngOnInit() {
  }
  managerFrameOut(){
    this.heroManagerAct='heroManagerAct'
  }
}
