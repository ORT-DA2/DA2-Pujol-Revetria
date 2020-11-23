import { Component, OnInit } from '@angular/core';
import { APIService } from '../api.service';
import { BookingConsult } from '../models/bookingconsult.model';

@Component({
  selector: 'app-adm-bookings',
  templateUrl: './adm-bookings.component.html',
  styleUrls: ['./adm-bookings.component.scss']
})
export class AdmBookingsComponent implements OnInit {

  constructor(private api : APIService) { }


  bookings : BookingConsult[] = []
  renderError = null;
  isFetching = false;


  ngOnInit(): void {
    this.getAllBookings();
  }

  getAllBookings(){
    this.isFetching = true;

    this.api.fetchAllBookings().subscribe(response=>{
      this.bookings = response;
      this.renderError = null;
      this.isFetching = false;

    },error=>{
      this.isFetching = false;

      this.renderError = error.error;
    })
  }
}
