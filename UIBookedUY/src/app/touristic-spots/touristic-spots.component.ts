import { Component, OnInit } from '@angular/core';
import {TouristicSpot} from '../models/touristicSpot.model';
import { Category } from '../models/category.model';
import { HttpClient } from '@angular/common/http';
import {
  FormBuilder,
  FormGroup,
  FormArray,
  FormControl,
  ValidatorFn
} from '@angular/forms';
import { CategoryComponent } from './category/category.component';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-touristic-spots',
  templateUrl: './touristic-spots.component.html',
  styleUrls: ['./touristic-spots.component.scss']
})
export class TouristicSpotsComponent implements OnInit {
  regionId : number =  1;
  Spots : TouristicSpot[];
  renderErrorCategories = null;
  renderErrorSpots = null;

  Categories : Category[] = [{id:1,name:"Playa",checked: false},{id:2,name:"Ciudad",checked: false}]

  constructor(private http : HttpClient, private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.regionId = this.route.snapshot.params['id'];
    this.getSpots("");
  }

  public searchByCategories(){
    let selectedCategoriesId : number[] = this.result.map(cat => {
      return cat.id;
    });
    this.getSpots(this.joinCategoriesToString(selectedCategoriesId));
  }

  joinCategoriesToString(array){
    let str = "";
    if(array.length>0){
    str = "&Categories=" + array.join("&Categories=");
    }
    return str;
  }

  get result() {
    return this.Categories.filter(item => item.checked);
  }

  public getCategories(){
      this.http.get<TouristicSpot[]>("https://localhost:5001/api/categories").subscribe(response=>{
        //this.Categories = response;
        this.renderErrorCategories = null;
    },error=>{
        this.renderErrorCategories = error.message;
    })
  };

  public getSpots(categories){
    this.http.get<TouristicSpot[]>("https://localhost:5001/api/touristicSpots?regionId="+this.regionId+ categories).subscribe(response=>{
      this.Spots = response;
      this.renderErrorSpots = null;
  },error=>{
      this.renderErrorSpots = error.message;
  });
}
}
