import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { APIService } from '../api.service';
import { ModalUnAuthorizedComponent } from '../modal-unauthorized/modal-unauthorized.component';
import { Admin } from '../models/admin.model';
import { SubmittedAdmin } from '../models/submittedadmin.model';

@Component({
  selector: 'app-adm-administrators',
  templateUrl: './adm-administrators.component.html',
  styleUrls: ['./adm-administrators.component.scss']
})
export class AdmAdministratorsComponent implements OnInit {

  constructor(private api : APIService) { }

  ngOnInit(): void {
    this.getAdmins();
  }

  public administrators : Admin[];
  renderError = null;
  deleteError = null;
  createError = null;

  childDeleted(event){
    let index =this.administrators.findIndex(admin=>admin.id==event);
    this.administrators.splice(index,1);
  }


  changeCreateError(){
    this.createError = null;
  }

  onSubmit(form : NgForm){
    let admin : SubmittedAdmin ={
      email: form.value.email,
      password: form.value.password
    };
    this.sendAdmin(admin,form);
  }

  sendAdmin(admin : SubmittedAdmin, form : NgForm){
    this.api.postAdmin(admin).subscribe(response=>{
      this.getAdmins();
      form.resetForm();
      this.createError = null;
    },error=>{
      if(error.error.text == "Administrator Created Successfully"){
        this.createError = null;
        this.getAdmins();
        form.resetForm();
      }else{
      this.createError = error.error;
      }
    })
  }



  public getAdmins(){
    this.api.fetchAllAdmins().subscribe(response => {
      this.administrators = response;
      this.renderError = null;
    },error => {
      this.renderError = error;
    })
  }



}
