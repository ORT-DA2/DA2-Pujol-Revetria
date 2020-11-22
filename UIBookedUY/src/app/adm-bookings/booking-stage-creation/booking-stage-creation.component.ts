import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from 'src/app/api.service';
import { BookingStage } from 'src/app/models/bookingstage.model';

@Component({
  selector: 'app-booking-stage-creation',
  templateUrl: './booking-stage-creation.component.html',
  styleUrls: ['./booking-stage-creation.component.scss']
})
export class BookingStageCreationComponent implements OnInit {

  bookingId : number;
  constructor(private route: ActivatedRoute,private api : APIService, private router : Router) {
    this.bookingId = parseInt(this.route.snapshot.params['id']);
  }

  creationError = null;

  submitStage(form : NgForm){
    let newStage : BookingStage = {
      description: form.value.description,
      status:form.value.status,
      AdminId:1,
      BookingId: this.bookingId
    }
    this.postStage(newStage);
  }

  ngOnInit(): void {
  }

  postStage(stage : BookingStage){
    this.api.postStage(stage).subscribe(response=>{
      this.router.navigate(["/adm-bookings"]);
      this.creationError = null;
    },error=>{
      this.creationError = error.error;
    })
  }

}
