import { Component, Input, OnInit } from '@angular/core';
import { Region } from 'src/app/models/region.model';

@Component({
  selector: 'app-region',
  templateUrl: './region.component.html',
  styleUrls: ['./region.component.scss']
})
export class RegionComponent implements OnInit {
  @Input() public region : Region;

  constructor() { }

  ngOnInit(): void {
  }

}
