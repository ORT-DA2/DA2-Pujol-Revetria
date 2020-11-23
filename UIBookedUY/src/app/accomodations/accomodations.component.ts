import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {Accommodation} from "../models/accommodation.model";
import { ActivatedRoute } from '@angular/router';
import { APIService } from '../api.service';
import { Category } from '../models/category.model';

@Component({
  selector: 'app-accomodations',
  templateUrl: './accomodations.component.html',
  styleUrls: ['./accomodations.component.scss']
})
export class AccomodationsComponent implements OnInit {

  public renderError = null;
  public accommodations : Accommodation[];
  public spotId : number;
  isFetching = false;



  constructor(private api : APIService, private route : ActivatedRoute ) { }

  ngOnInit(): void {
    this.spotId = this.route.snapshot.params['id'];
    this.getAccommodations();
  }

  imagesToSlides(images : string[]){
    let slides = [];
    images.forEach(img=>{
      slides.push({'image':img});
    })
    return slides;
  }

  public getAccommodations(){
    this.isFetching = true;

    this.api.fetchAccommodationsBySpot(this.spotId).subscribe(response=>{
      this.accommodations = response;
      this.renderError = null;
      this.isFetching = false;
    },error=>{
      this.isFetching = false;
      this.renderError = error.message;
    })
  }
}
