import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
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

  constructor(private api : APIService, public dialog: MatDialog) { }

  @Input() admin : Admin;

  ngOnInit(): void {
  }

  changeDeleteErrror(){
    this.deleteError = null;
  }

  openDialog(errorMsg): void {
    const dialogRef = this.dialog.open(ModalUnAuthorizedComponent, {
      width: '250px',
      data: {error: errorMsg}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  deleteAdmin(id){
    this.api.deleteAdmin(id).subscribe(response=>{
      this.deleteError = null;
    },error=>{
      if(error.status==403 || error.status==401){
        this.openDialog(error.error);
      }else{
      this.deleteError = error.error;
      }
    });
  }


}
