import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Region } from '../models/region.model';

@Component({
  selector: 'app-regions',
  templateUrl: './regions.component.html',
  styleUrls: ['./regions.component.scss']
})
export class RegionsComponent implements OnInit {

  renderError = null;

  Regions : Region[];

  constructor(private http : HttpClient) { }

  ngOnInit(): void {
    this.getRegions();
  }


  public getRegions(){
    this.http.get<Region[]>("https://localhost:5001/api/regions").subscribe(response=>{
      this.Regions = response;
    },error=>{
      this.renderError = error.message;
    })
  }

}
