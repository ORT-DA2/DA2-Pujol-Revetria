import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {  catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { Accommodation } from './models/accommodation.model';
import { Admin } from './models/admin.model';
import { Booking } from './models/booking.model';
import { BookingConsult } from './models/bookingconsult.model';
import { Category } from './models/category.model';
import { Region } from './models/region.model';
import { SubmittedReview } from './models/submitedreview.model';
import { SubmittedAdmin } from './models/submittedadmin.model';
import { SubmittedSpot } from './models/submittedSpot.model';
import { TouristicSpot } from './models/touristicSpot.model';
import { SubmittedAccommodation } from './models/submittedAccommodation.model';
import { BookingStage } from './models/bookingstage.model';
import { Report } from './models/report.model';
import { ModalUnAuthorizedComponent } from './modal-unauthorized/modal-unauthorized.component';
import { MatDialog } from '@angular/material/dialog';

class Token{
  token : string
}

@Injectable({
  providedIn: 'root'
})
export class APIService {




  url = "https://localhost:5001/api/";
  constructor(private http : HttpClient, private auth : AuthService, public dialog: MatDialog) { }

  openDialog(errorMsg): void {
    const dialogRef = this.dialog.open(ModalUnAuthorizedComponent, {
      width: '250px',
      data: {error: errorMsg}
    });
  }

  fetchBookingStatus(id: number) {
    return this.http.get<BookingStage>(this.url + "bookingstages/" + id).pipe(
      map(data=>{
        const stage : BookingStage = {description:"",status:""};
        for(const key in data){
          if(data.hasOwnProperty(key)){
          stage[key] = data[key];
          }
        }
        return stage;
    }));
  }

  postAccommodation(newAccommodation: SubmittedAccommodation) {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: this.auth.getToken()
      })}
    return this.http.post(this.url + "accommodations",newAccommodation,httpOptions);
  }

  tryLogin(email, password){
    return this.http.get<Token>(this.url+"administrators/login?email="+email+"&password="+password);
  }

  fetchRegions(){
    return this.http.get<Region[]>(this.url + "regions");
  }

  fetchSpots(regionId: number, categories){
    return this.http.get<TouristicSpot[]>(this.url + "touristicspots?regionId="+ regionId+ categories);
  }

  fetchCategories(){
    return this.http.get<Category[]>(this.url + "categories");
  }

  postReview(review : SubmittedReview){
    return this.http.post(this.url + "accommodations/review", review);
  }

  postSpot(spot : SubmittedSpot){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: this.auth.getToken()
      })}
    return this.http.post(this.url + "touristicspots",spot,httpOptions);
  }

  postStage(stage : BookingStage){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: this.auth.getToken()
      })}
    return this.http.post(this.url + "bookingstages",stage,httpOptions).pipe(catchError(error=>{
      if(error.status==403 || error.status==401){
        this.openDialog(error.error);
      }
      return error;
    }));
  }

  postAdmin(admin : SubmittedAdmin){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: this.auth.getToken()
      })}
    return this.http.post(this.url + "administrators",admin,httpOptions).pipe(catchError(error=>{
      if(error.status==403 || error.status==401){
        this.openDialog(error.error);
      }
      return error;
    }));
  }

  postBooking(booking){
    return this.http.post<Booking>(this.url + "bookings",booking);
  }

  fetchBooking(code: number){
    return this.http.get<BookingConsult>(this.url + "bookings/"+code);
  }

  fetchAllBookings(){
    return this.http.get<BookingConsult[]>(this.url + "bookings");
  }

  fetchAccommodation(accommodationId){
    return this.http.get<Accommodation>(this.url + "accommodations/"+ accommodationId);
  }

  fetchAllSpots(){
    return this.http.get<TouristicSpot[]>(this.url + "touristicspots");
  }

  fetchAccommodationsBySpot(spotId: number){
    return this.http.get<Accommodation[]>(this.url + "accommodations/spot/"+ spotId);
  }

  fetchReport(spotName: string, startDate : string, endDate : string){
    return this.http.get<Report[]>(this.url + "reports?touristicSpotName="+spotName +"&start="+ startDate +"&end="+ endDate);
  }

  fetchImportNames(){
    return this.http.get(this.url + "importers");
  }

  fetchAllAccommodations(){
    return this.http.get(this.url + "accommodations").pipe(
      map(data=>{
        const accoms : Accommodation[] = [];
        for(const key in data){
          if(data.hasOwnProperty(key)){
          accoms.push({...data[key]})
          }
        }
        return accoms;
    }));
  }

  fetchAllAdmins(){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: this.auth.getToken()
      })}
    return this.http.get<Admin[]>(this.url + "administrators",httpOptions).pipe(catchError(error=>{
      if(error.status==403 || error.status==401){
        this.openDialog(error.error);
      }
      return error;
    }));
  }

  deleteAdmin(id: number){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: this.auth.getToken()
      })}
    return this.http.delete(this.url + "administrators/" + id,httpOptions).pipe(catchError(error=>{
      if(error.status==403 || error.status==401){
        this.openDialog(error.error);
      }
      return error;
    }));
  }

  deleteAccommodation(id: number){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: this.auth.getToken()
      })}
    return this.http.delete(this.url + "accommodations/" + id,httpOptions).pipe(catchError(error=>{
      if(error.status==403 || error.status==401){
        this.openDialog(error.error);
      }
      return error;
    }));
  }

  updateAccommodationStatus(id : number,status : boolean){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: this.auth.getToken()
      })}
    return this.http.put(this.url + "accommodations/" + id,status,httpOptions).pipe(catchError(error=>{
      if(error.status==403 || error.status==401){
        this.openDialog(error.error);
      }
      return error;
    }));
  }

}
