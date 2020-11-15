import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Accommodation } from '../models/accommodation.model';
import { Booking } from '../models/booking.model';
@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent implements OnInit {

  minDate : Date;
  public form : NgForm;
  formError = null;
  renderError = null;
  validDate : boolean = true;
  bookingCode : number = null;
  guestsValid : boolean = true;

  range = new FormGroup({
    start: new FormControl(new Date()),
    end: new FormControl(new Date(new Date().getFullYear(),new Date().getMonth(),new Date().getDate()+1))
  });

  onSubmit(form :NgForm){
    if(this.range.value.start>new Date()){
      if(form.value.adultAmount>0 || form.value.elderlyAmount>0|| form.value.childAmount>0|| form.value.infantAmount>0){
      let newBooking : Booking = {
      id: null,
      accommodationId: this.accommodation.id,
      checkIn: this.range.value.start.toISOString().substring(0,10),
      CheckOut: this.range.value.end.toISOString().substring(0,10),
      GuestEmail: form.value.email,
      GuestName: form.value.name,
      GuestLastName: form.value.lastname,
      Guests: [
        {
          Amount: form.value.elderlyAmount ? form.value.elderlyAmount : 0,
          Multiplier:0.7,
        },
        {
          Amount: form.value.adultAmount ? form.value.adultAmount : 0,
          Multiplier:1,
        },
        {
          Amount: form.value.childAmount ? form.value.childAmount : 0,
          Multiplier:0.5,
        },
        {
          Amount: form.value.infantAmount ? form.value.infantAmount : 0,
          Multiplier:0.3,
        }
      ],
    }
    this.validDate = false;
    this.sendBooking(newBooking,form);
    }else{
      this.guestsValid = false;
    }
  }else{
  this.validDate = false;
  }
  }

  public accommodation : Accommodation = new Accommodation();

  constructor(private http : HttpClient, private route : ActivatedRoute) {
    this.accommodation.id = this.route.snapshot.params['id'];
    this.getAccommodation();
    const currentYear = new Date().getFullYear();
    const currentMonth = new Date().getMonth();
    this.minDate = new Date(currentYear, currentMonth, 1);
  }

  ngOnInit(): void {
  }

  public isDateValid() : boolean{
    if(this.range.value.start&&this.range.value.end&&this.range.value.start>Date()){
      if(this.range.value.start<this.range.value.end){
        return true;
      }
    }
    return false;
  }

  public toArrayScore(){
    let scoreArr : number[] = [];
    let auxScore : number;
    for (auxScore = this.accommodation.score; auxScore > 0; auxScore--) {
      scoreArr.push(1);
    }
    if(auxScore>=0.3&&auxScore<=0.7){
      scoreArr.push(0.5);
    }
    for(let i = scoreArr.length; i<5;i++){
      scoreArr.push(0);
    }
    return scoreArr;
  }

  private sendBooking(booking : Booking, form : NgForm){
    this.http.post<Booking>("https://localhost:5001/api/bookings",booking).subscribe(response=>{
      this.formError = null;
      this.bookingCode = response.id;
      form.resetForm();
      this.validDate = true;
      this.guestsValid = true;
    },error=>{
      this.formError = error;
      this.bookingCode = null;
    });
  }

  public getAccommodation(){
    this.http.get<Accommodation>("https://localhost:5001/api/accommodations/"+this.accommodation.id).subscribe(response=>{
      this.accommodation = response;
      this.renderError = null;
    },error=>{
      this.renderError = error.message;
    });
  }

}
