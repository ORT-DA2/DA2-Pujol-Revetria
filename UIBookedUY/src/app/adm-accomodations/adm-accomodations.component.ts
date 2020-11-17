import { Component, OnInit } from '@angular/core';
import { APIService } from '../api.service';
import { Accommodation } from '../models/accommodation.model';

@Component({
  selector: 'app-adm-accomodations',
  templateUrl: './adm-accomodations.component.html',
  styleUrls: ['./adm-accomodations.component.scss']
})
export class AdmAccomodationsComponent implements OnInit {

  public renderError = null;
  public accommodations : Accommodation[];


  constructor(private api : APIService) { }

  ngOnInit(): void {
    this.getAccommodations();
  }

  public getAccommodations(){
    this.api.fetchAccommodationsBySpot("").subscribe(response=>{
      this.accommodations = response;
      this.renderError = null;
    },error=>{
      this.renderError = error.message;
    })
  }
}
