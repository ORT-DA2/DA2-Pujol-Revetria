import { Component, Input, OnInit } from '@angular/core';
import { Region } from 'src/app/models/region.model';

@Component({
  selector: 'app-region',
  templateUrl: './region.component.html',
  styleUrls: ['./region.component.scss']
})
export class RegionComponent implements OnInit {
  @Input() public region : Region;

  images = ["https://turismo.gub.uy/images/litoral-sur-map.png",
  "https://turismo.gub.uy/images/region-sur-map.png",
  "https://turismo.gub.uy/images/region-centro-map.png",
  "https://turismo.gub.uy/images/region-este-map.png",
  "https://turismo.gub.uy/images/region-noreste-map.png"];

  constructor() { }

  ngOnInit(): void {
  }

  data = [1,2,3,4,5,6];
  colors=['red','blue','green','pink'];
  randomItem;

  getRandomTransparency(){
    return Math.random();
  }

  getImage(regionId) : string{

    return this.images[regionId-1];
  }

}
