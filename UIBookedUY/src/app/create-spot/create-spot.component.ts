import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { APIService } from '../api.service';
import { Category } from '../models/category.model';
import { Region } from '../models/region.model';
import { SubmittedSpot } from '../models/submittedSpot.model';

@Component({
  selector: 'app-create-spot',
  templateUrl: './create-spot.component.html',
  styleUrls: ['./create-spot.component.scss']
})
export class CreateSpotComponent implements OnInit {

  constructor(private api: APIService) { }

  ngOnInit(): void {
    this.refresh();
  }


  refresh() {
    this.getRegions();
    this.getCategories();
  }

  renderError = null;

  Categories: Category[];
  Regions: Region[];

  submitSpot(form: NgForm) {
    if(this.file && this.file.type.match('image.*')){
      let newSpot :SubmittedSpot = {
        categories: form.value.categoriesSelect,
        description: form.value.desc,
        image: this.image64,
        name: form.value.nameSpot,
        regionId: form.value.regionSelect,
      }
      this.postSpot(newSpot);
    }
  }

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

  public postSpot(spot) {
    this.api.postSpot(spot).subscribe(response=>{

    },error=>{

    })
  }

  public getCategories(){
      this.api.fetchCategories().subscribe(response=>{
        this.Categories = response;
        this.renderError = null;
    },error=>{
        this.renderError = error.message;
    })
  }

  public getRegions() {
    this.api.fetchRegions().subscribe(response => {
      this.Regions = response;
    }, error => {
      this.renderError = error.message;
    })
  }

}
