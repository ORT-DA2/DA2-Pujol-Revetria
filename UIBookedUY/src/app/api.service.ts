import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Accommodation } from './models/accommodation.model';
import { Booking } from './models/booking.model';
import { BookingConsult } from './models/bookingconsult.model';
import { Category } from './models/category.model';
import { Region } from './models/region.model';
import { SubmittedReview } from './models/submitedreview.model';
import { SubmittedSpot } from './models/submittedSpot.model';
import { TouristicSpot } from './models/touristicSpot.model';

class Token{
  token : string
}

@Injectable({
  providedIn: 'root'
})
export class APIService {

  url = "https://localhost:5001/api/";
  constructor(private http : HttpClient) { }

  tryLogin(email, password){
    return this.http.get<Token>(this.url+"administrators/login?email="+email+"&password="+password);
  }

  fetchRegions(){
    return this.http.get<Region[]>(this.url + "regions");
  }

  fetchSpots(regionId, categories){
    return this.http.get<TouristicSpot[]>(this.url + "touristicspots?regionId="+ regionId+ categories);
  }

  fetchCategories(){
    return this.http.get<Category[]>(this.url + "categories");
  }

  postReview(review : SubmittedReview){
    return this.http.post(this.url + "accommodations/review", review);
  }

  postSpot(spot : SubmittedSpot){
    return this.http.post(this.url + "touristicspots",spot);
  }

  postBooking(booking){
    return this.http.post<Booking>(this.url + "bookings",booking);
  }

  fetchBooking(code){
    return this.http.get<BookingConsult>(this.url + "bookings/"+code);
  }

  fetchAccommodation(accommodationId){
    return this.http.get<Accommodation>(this.url + "accommodations/"+ accommodationId);
  }

  fetchAllSpots(){
    return this.http.get<TouristicSpot[]>(this.url + "touristicspots");
  }

  fetchAccommodationsBySpot(spotId){
    return this.http.get<Accommodation[]>(this.url + "accommodations/spot/"+ spotId);
  }

  fetchAllAccommodations(){
    return this.http.get<Accommodation[]>(this.url + "accommodations");
  }

}
