import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegionsComponent } from './regions/regions.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material-module';
import { HeaderComponent } from './header/header.component';
import { RegionComponent } from './regions/element/region/region.component';
import { TouristicSpotsComponent } from './touristic-spots/touristic-spots.component';
import { SpotComponent } from './touristic-spots/element/spot/spot.component';
import { CategoryComponent } from './touristic-spots/category/category.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { AccomodationsComponent } from './accomodations/accomodations.component';
import { AccomodationComponent } from './accomodations/element/accomodation/accomodation.component';
import { BookingComponent } from './booking/booking.component';
import { ReviewComponent } from './booking/review/review.component';
import { CreateReviewComponent } from './create-review/create-review.component';
import { RatingModule } from 'ng-starrating';
import { CreateSpotComponent } from './create-spot/create-spot.component';
import { AdmAccomodationsComponent } from './adm-accomodations/adm-accomodations.component';
import { AuthService } from './auth.service';
import { AudioService } from './audio-service.service';
import { AuthGuard } from './authguard.service';
import { CommonModule } from "@angular/common";
import { MatCarouselModule } from '@ngmodule/material-carousel';
import { OwlModule } from 'ngx-owl-carousel';

@NgModule({
  declarations: [
    AppComponent,
    RegionsComponent,
    HeaderComponent,
    RegionComponent,
    TouristicSpotsComponent,
    SpotComponent,
    CategoryComponent,
    LoginComponent,
    AccomodationsComponent,
    AccomodationComponent,
    BookingComponent,
    ReviewComponent,
    CreateReviewComponent,
    CreateSpotComponent,
    AdmAccomodationsComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    HttpClientModule,
    RatingModule,
    MatCarouselModule
  ],
  providers: [AuthService, AuthGuard,AudioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
