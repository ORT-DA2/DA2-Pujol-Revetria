import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { APIService } from '../api.service';
import { Accommodation } from '../models/accommodation.model';
import { TouristicSpot } from '../models/touristicSpot.model';

@Component({
  selector: 'app-adm-accomodations',
  templateUrl: './adm-accomodations.component.html',
  styleUrls: ['./adm-accomodations.component.scss']
})
export class AdmAccomodationsComponent implements OnInit {

  public renderError = null;
  public accommodations : Accommodation[];
  public Spots : TouristicSpot[];

  constructor(private api : APIService) { }

  @ViewChild('fileInput')
  fileInput;

  file: File | null = null;

  image64;

  onClickFileInputButton(): void {
    this.fileInput.nativeElement.click();
  }

  onChangeFileInput(): void {
    const files: { [key: string]: File } = this.fileInput.nativeElement.files;
    this.file = files[0];
    this.getBase64Image();
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
    //this.getAccommodations();
    this.getSpots();
  }

  submitAccommodation(form : NgForm){

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
    this.api.fetchAllAccommodations().subscribe(response=>{
      this.accommodations = response;
      this.renderError = null;
    },error=>{
      this.renderError = error.message;
    })
  }
}
