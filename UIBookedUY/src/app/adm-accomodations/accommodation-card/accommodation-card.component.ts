import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { APIService } from 'src/app/api.service';
import { ModalUnAuthorizedComponent } from 'src/app/modal-unauthorized/modal-unauthorized.component';
import { Accommodation } from 'src/app/models/accommodation.model';

@Component({
  selector: 'app-accommodation-card',
  templateUrl: './accommodation-card.component.html',
  styleUrls: ['./accommodation-card.component.scss']
})
export class AccommodationCardComponent implements OnInit {

  constructor(private api : APIService, public dialog: MatDialog) { }

  @Input() accommdoation : Accommodation;

  @Output() deleteEvent = new EventEmitter<number>();

  ngOnInit(): void {
  }

  openDialog(errorMsg): void {
    const dialogRef = this.dialog.open(ModalUnAuthorizedComponent, {
      width: '250px',
      data: {error: errorMsg}
    });
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
