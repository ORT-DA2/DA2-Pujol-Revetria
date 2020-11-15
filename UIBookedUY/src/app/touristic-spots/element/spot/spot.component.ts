import { Component, Input, OnInit } from '@angular/core';
import { TouristicSpotsComponent } from '../../touristic-spots.component';
import {TouristicSpot} from "../../../models/touristicSpot.model"

@Component({
  selector: 'app-spot',
  templateUrl: './spot.component.html',
  styleUrls: ['./spot.component.scss']
})
export class SpotComponent implements OnInit {

  @Input() Spot : TouristicSpot

  constructor() { }

  public getImageSrc(){
    return 'data:image/jpg;base64,' + this.Spot.image;
  }

  ngOnInit(): void {
  }

}
