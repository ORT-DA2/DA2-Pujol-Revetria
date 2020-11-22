import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { APIService } from 'src/app/api.service';
import { Accommodation } from 'src/app/models/accommodation.model';

@Component({
  selector: 'app-accommodation-card',
  templateUrl: './accommodation-card.component.html',
  styleUrls: ['./accommodation-card.component.scss']
})
export class AccommodationCardComponent implements OnInit {

  constructor(private api : APIService) { }

  @Input() accommdoation : Accommodation;

  @Output() deleteEvent = new EventEmitter<number>();

  ngOnInit(): void {
  }

  changeFull(status : boolean){
    this.api.updateAccommodationStatus(this.accommdoation.id,status).subscribe(response=>{

    },error=>{

    })
  }

  deleteAccommdoation(){
   this.api.deleteAccommodation(this.accommdoation.id).subscribe(response=>{
    this.deleteEvent.emit(this.accommdoation.id);
   },error=>{

   });
  }

}
