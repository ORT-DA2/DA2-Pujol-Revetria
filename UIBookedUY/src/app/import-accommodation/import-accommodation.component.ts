import { Component, OnInit } from '@angular/core';
import { APIService } from '../api.service';

@Component({
  selector: 'app-import-accommodation',
  templateUrl: './import-accommodation.component.html',
  styleUrls: ['./import-accommodation.component.scss']
})
export class ImportAccommodationComponent implements OnInit {

  constructor(private api : APIService) { }

  importNames;

  ngOnInit(): void {
    this.getImportNames();
  }

  getImportNames(){
    this.api.fetchImportNames().subscribe(response=>{
      this.importNames = response;
      console.log(response);
    },error=>{

    })
  }

}
