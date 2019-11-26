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
  protected heroManagerAct:string=''
  constructor(public publicSrc:PublicSrcService) { }

  ngOnInit() {
  }
  managerFrameOut(){
    this.heroManagerAct='heroManagerAct'
  }
}
