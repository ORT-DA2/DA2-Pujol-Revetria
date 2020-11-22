import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { APIService } from '../api.service';
import { Report } from '../models/report.model';
import { TouristicSpot } from '../models/touristicSpot.model';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {

  constructor(private api : APIService) { }

  fetchError = null;
  renderError = null;
  spots : TouristicSpot[];
  reports : Report[] = [];

  range = new FormGroup({
    start: new FormControl(new Date()),
    end: new FormControl(new Date(new Date().getFullYear(),new Date().getMonth(),new Date().getDate()+1))
  });

  ngOnInit(): void {
    this.getSpots();
  }

  public getSpots(){
    this.api.fetchAllSpots().subscribe(response=>{
      this.spots = response;
      this.renderError = null;
    },error=>{
      this.renderError = error.message;
    })
  }

  trimToISODate(date : string){
    return date.substring(0,10);
  }

  askReport(form : NgForm){
    this.getReport(form.value.spot, this.trimToISODate(this.range.value.start.toISOString()),this.trimToISODate(this.range.value.end.toISOString()))
  }

  getReport(name,start,end){
    this.api.fetchReport(name,start,end).subscribe(response=>{
      this.fetchError = null;
      this.reports = response;
    },error=>{
      this.reports = [];
      this.fetchError = error.error;
    })
  }
}
