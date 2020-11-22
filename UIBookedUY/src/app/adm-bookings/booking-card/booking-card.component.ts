
import { Component, Input, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { APIService } from 'src/app/api.service';
import { BookingConsult } from 'src/app/models/bookingconsult.model';
import { BookingStage } from 'src/app/models/bookingstage.model';

@Component({
  selector: 'app-booking-card',
  templateUrl: './booking-card.component.html',
  styleUrls: ['./booking-card.component.scss']
})
export class BookingCardComponent implements OnInit {

  constructor(private api : APIService, private router : Router) { }

  @Input() booking : BookingConsult;
  stage : BookingStage = null;
  stringNoStage = null;


  openBookingStage(){
    this.router.navigate(["create-stage/" + this.booking.id])
  }

  getCheckInOut(){
    return this.booking.checkIn.substring(0,10) + " - " + this.booking.checkOut.substring(0,10);
  }

  ngOnInit(): void {
    this.getBookingStatus();
  }

  getBookingStatus(){
    this.api.fetchBookingStatus(this.booking.id).subscribe(response=>{
      this.stage = response;
    },error=>{
      this.stringNoStage = error.error.text
    })
  }

}
