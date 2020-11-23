import { FocusKeyManager } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { APIService } from '../api.service';
import { Accommodation } from '../models/accommodation.model';
import { SubmittedAccommodation } from '../models/submittedAccommodation.model';
import { TouristicSpot } from '../models/touristicSpot.model';

@Component({
  selector: 'app-adm-accomodations',
  templateUrl: './adm-accomodations.component.html',
  styleUrls: ['./adm-accomodations.component.scss']
})
export class AdmAccomodationsComponent implements OnInit {

  public renderError = null;
  public creationError = null;

  public deletedId : number;

  public accommodations : Accommodation[] = [];

  public Spots : TouristicSpot[];
  isFetching = false;


  constructor(private api : APIService) { }

  @ViewChild('fileInput')
  fileInput;

  file: File | null = null;

  fileInputTouched : boolean = false

  image64;

  childDeleted(event){
    let index =this.accommodations.findIndex(accom=>accom.id==event);
    this.accommodations.splice(index,1);
  }

  onClickFileInputButton(): void {
    this.fileInput.nativeElement.click();
  }

  onChangeFileInput(): void {
    const files: { [key: string]: File } = this.fileInput.nativeElement.files;
    this.file = files[0];
    this.getBase64Image();
    this.fileInputTouched = true;
  }

  public getBase64Image() {
    if (this.file && this.file.type.match('image.*')) {
      let me = this;
      let reader = new FileReader();
      reader.readAsDataURL(this.file);

      reader.onload = function () {
        me.image64 = reader.result;
      };
      reader.onerror = function (error) {
        throw error;
      };
    }
  }

  images : string[] = [];
  imagesNames : {name:string,index:number}[] = [];
  countImages = 0;

  public storeImage(){
    this.images.push(this.image64);
    this.imagesNames.push({name:this.file.name,index:this.countImages++});
    this.file = null;
    this.image64 = null;
    console.log(this.images);
  }

  deleteImage(index){
    this.imagesNames.splice(index, 1);
    this.images.splice(index,1);
    this.countImages--;
  }

  ngOnInit(): void {
    this.getAccommodations();
    this.getSpots();
    console.log(this.images.length)
  }

  submitAccommodation(form : NgForm){
    if(this.images.length<1){
      this.fileInputTouched = true;
    }else{
    let newAccommodation : SubmittedAccommodation = {
      Address: form.value.addressAccommodation,
      Contact: form.value.contactAccommodation,
      Information: form.value.information,
      Name: form.value.nameAccommodation,
      SpotId: parseInt(form.value.spotId),
      images: this.images,
      price: form.value.price
    }
    this.postAccommodation(newAccommodation, form);
  }

  }

  postAccommodation(newAccommodation: SubmittedAccommodation, form : NgForm) {
    this.api.postAccommodation(newAccommodation).subscribe(response=>{
      form.resetForm();
      this.getAccommodations();
      this.images = [];
      this.imagesNames = [];
      this.countImages = 0;
      this.creationError = null;
      this.fileInputTouched = false;
    },error=>{
      this.creationError = error.error
    });
  }

  public getSpots(){
    this.api.fetchAllSpots().subscribe(response=>{
      this.Spots = response;
      this.renderError = null;
    },error=>{
      this.renderError = error.message;
    })

  }

  public getAccommodations(){
    this.isFetching = true;

    this.api.fetchAllAccommodations().subscribe(response=>{
      this.accommodations = response;
      this.renderError = null;
      this.isFetching = false;
    },error=>{
      this.renderError = error.message;
      this.isFetching = false;
    });
  }
}
