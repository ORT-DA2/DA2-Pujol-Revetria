import { Component, Input, OnInit } from '@angular/core';
import {Accommodation} from "../../../models/accommodation.model"

@Component({
  selector: 'app-accomodation',
  templateUrl: './accomodation.component.html',
  styleUrls: ['./accomodation.component.scss']
})
export class AccomodationComponent implements OnInit {

  @Input() public accommodation : Accommodation;

  public toArrayScore(){
    let scoreArr : number[] = [];
    let auxScore : number;
    for (auxScore = this.accommodation.score; auxScore > 0; auxScore--) {
      scoreArr.push(1);
    }
    if(auxScore>=0.3&&auxScore<=0.7){
      scoreArr.push(0.5);
    }
    for(let i = scoreArr.length; i<5;i++){
      scoreArr.push(0);
    }
    return scoreArr;
  }

  slides = [{'image': 'https://turismo.gub.uy/images/region-noreste-map.png'},
            {'image': 'https://turismo.gub.uy/images/region-este-map.png'},
            {'image': 'https://turismo.gub.uy/images/region-centro-map.png'}];




  constructor() { }

  ngOnInit(): void {
  }

}
