import { Component, OnInit } from '@angular/core';
import { APIService } from '../api.service';

@Component({
  selector: 'app-import-accommodation',
  templateUrl: './import-accommodation.component.html',
  styleUrls: ['./import-accommodation.component.scss']
})
export class ImportAccommodationComponent implements OnInit {

  constructor(private api : APIService) { }

  isFetching = false;

  importNames;

  ngOnInit(): void {
    this.getImportNames();
  }

  getImportNames(){
    this.isFetching = true;
    this.api.fetchImportNames().subscribe(response=>{
      this.importNames = response;
      console.log(response);
      this.isFetching = false;
    },error=>{
      this.isFetching = false;
    })
  }

}
