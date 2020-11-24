import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { format } from 'path';
import { APIService } from '../api.service';
import { ImporterSubmitted, ParameterOut } from '../models/impoertersubmitted.model';
import { ImportParameter } from '../models/importparameters.model';

@Component({
  selector: 'app-import-accommodation',
  templateUrl: './import-accommodation.component.html',
  styleUrls: ['./import-accommodation.component.scss']
})
export class ImportAccommodationComponent implements OnInit {
  importError: any = null;
  responseCreation: Object = null;
  fetchError: any = null;

  constructor(private api : APIService) { }

  isFetching = false;

  importNames : string[]= [];

  paramters : ImportParameter[] = [];

  ngOnInit(): void {
    this.getImportNames();
  }

  isString(variable){
    return variable === "string";
  }

  isNumber(variable){
    return variable === "integer"
  }

  isBoolean(variable){
    return variable === "boolean";
  }

  onSubmit(form : NgForm){
    let newImport : ImporterSubmitted = {
      name : form.value.importNamesSelect,
      parameters : this.transformToOutParameters(form)
    };
    this.postImporter(newImport);
  }

  transformToOutParameters(form : NgForm) : ParameterOut[]{
    let params : ParameterOut[] = [];
    for(const key in form.value){
      if(form.value.hasOwnProperty(key)&&key!=="importNamesSelect"){
        params.push({name:key,value:form.value[key]})
      }
    }
    return params;
  }

  getParameters(importName){
    this.isFetching = true;
    this.api.fetchParameters(importName).subscribe(response=>{
      this.paramters = response;
      this.fetchError = null;
      this.isFetching = false;
    },error=>{
      this.fetchError = error.error;
      this.isFetching = false;
    })
  }

  postImporter(imp : ImporterSubmitted){
    this.api.postImporter(imp).subscribe(response=>{
      this.responseCreation = response;
      this.importError = null;
    }, error=>{
      this.importError = error.error;
    });
  }

  getImportNames(){
    this.isFetching = true;
    this.api.fetchImportNames().subscribe(response=>{
      this.importNames = response;
      this.isFetching = false;
      this.fetchError = null;
    },error=>{
      this.isFetching = false;
      this.fetchError = error.error;
    })
  }

}
