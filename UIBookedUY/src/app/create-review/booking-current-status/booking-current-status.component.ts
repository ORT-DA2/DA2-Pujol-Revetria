import { Component, Input, OnInit } from '@angular/core';
import { APIService } from 'src/app/api.service';
import { BookingConsult } from 'src/app/models/bookingconsult.model';
import { BookingStage } from 'src/app/models/bookingstage.model';

@Component({
  selector: 'app-booking-current-status',
  templateUrl: './booking-current-status.component.html',
  styleUrls: ['./booking-current-status.component.scss']
})
export class BookingCurrentStatusComponent implements OnInit {

  constructor(private api : APIService) { }

  @Input() booking : number;

  stringNoStage = null;

  stage : BookingStage = null;

  ngOnInit(): void {
    this.getBookingStatus();
  }

  getBookingStatus(){
    this.api.fetchBookingStatus(this.booking).subscribe(response=>{
      this.stage = response;
    },error=>{
      this.stringNoStage = error.error.text
    })
  }

}
