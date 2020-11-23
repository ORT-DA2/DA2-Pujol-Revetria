import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { APIService } from '../api.service';
import { Region } from '../models/region.model';

@Component({
  selector: 'app-regions',
  templateUrl: './regions.component.html',
  styleUrls: ['./regions.component.scss']
})
export class RegionsComponent implements OnInit {

  renderError = null;
  isFetching = false;
  Regions : Region[];

  constructor(private api : APIService) { }

  ngOnInit(): void {
    this.getRegions();
  }



  public getRegions(){
    this.isFetching = true;
    this.api.fetchRegions().subscribe(response=>{
      this.Regions = response;
      this.isFetching = false;
    },error=>{
      this.renderError = error.message;
      this.isFetching = false;
    })
  }

}
