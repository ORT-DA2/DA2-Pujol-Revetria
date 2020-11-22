import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

export interface DialogData {
  error: string;
}

@Component({
  selector: 'modal-unauthorized',
  templateUrl: 'modal-unauthorized.component.html',
})
export class ModalUnAuthorizedComponent {

  constructor(
    public dialogRef: MatDialogRef<ModalUnAuthorizedComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData, private router : Router, private auth : AuthService) {}

  close(): void {
    this.auth.logOut();
    this.router.navigate(['/login']);
    this.dialogRef.close();
  }

}
