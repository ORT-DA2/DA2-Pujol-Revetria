import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { APIService } from '../api.service';
import { BookingConsult } from '../models/bookingconsult.model';
import { SubmittedReview } from '../models/submitedreview.model';

@Component({
  selector: 'app-create-review',
  templateUrl: './create-review.component.html',
  styleUrls: ['./create-review.component.scss'],
  encapsulation: ViewEncapsulation.Emulated
})
export class CreateReviewComponent implements OnInit {

  constructor(private api : APIService) {

   }

  booking : BookingConsult;
  bookingNotFound = null;
  reviewResponse = null;
  reviewError = null;

  ngOnInit(): void {

  }

  public submitReview(form){
    let review : SubmittedReview = {
      BookingId : this.booking.id,
      Comment : form.value.comment,
      Score : Number(form.value.rating=="" ? 0:form.value.rating),
    }
    console.log(review);
    this.createReview(review, form);
  }

  public onSubmit(form){
    this.getBooking(form.value.bookingcode);
  }

  private createReview(review : SubmittedReview, form : NgForm){
    this.api.postReview(review).subscribe(response=>{
      console.log(response);
      form.resetForm();
      this.reviewResponse = response;
    },error=>{
      this.reviewError = error;
      this.reviewResponse = null
    });
  }

  private getBooking(code){
    this.api.fetchBooking(code).subscribe(response=>{
      this.booking = response;
      this.bookingNotFound = null;
    },error=>{
      this.bookingNotFound = error;
      this.booking = null
    });
  }
}
