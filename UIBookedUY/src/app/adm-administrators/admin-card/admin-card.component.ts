import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { APIService } from 'src/app/api.service';
import { ModalUnAuthorizedComponent } from 'src/app/modal-unauthorized/modal-unauthorized.component';
import { Admin } from 'src/app/models/admin.model';

@Component({
  selector: 'app-admin-card',
  templateUrl: './admin-card.component.html',
  styleUrls: ['./admin-card.component.scss']
})
export class AdminCardComponent implements OnInit {
  deleteError = null;

  constructor(private api : APIService) { }

  @Input() admin : Admin;

  @Output() deleteEvent : EventEmitter<number> = new EventEmitter<number>();

  ngOnInit(): void {
  }

  changeDeleteErrror(){
    this.deleteError = null;
  }

  deleteAdmin(id){
    this.api.deleteAdmin(id).subscribe(response=>{
      this.deleteError = null;
      this.deleteEvent.emit(id);
    },error=>{
      this.deleteError = error.error;
    });
  }


}
