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
import { AdmAdministratorsComponent } from './adm-administrators/adm-administrators.component';
import { AdmBookingsComponent } from './adm-bookings/adm-bookings.component';
import { AccommodationCardComponent } from './adm-accomodations/accommodation-card/accommodation-card.component';
import { BookingCardComponent } from './adm-bookings/booking-card/booking-card.component';
import { BookingStageCreationComponent } from './adm-bookings/booking-stage-creation/booking-stage-creation.component';
import { BookingCurrentStatusComponent } from './create-review/booking-current-status/booking-current-status.component';
import { ReportComponent } from './report/report.component';
import { ModalUnAuthorizedComponent } from './modal-unauthorized/modal-unauthorized.component';
import { AdminCardComponent } from './adm-administrators/admin-card/admin-card.component';
import { ImportAccommodationComponent } from './import-accommodation/import-accommodation.component';

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
    AdmAdministratorsComponent,
    AdmBookingsComponent,
    AccommodationCardComponent,
    BookingCardComponent,
    BookingStageCreationComponent,
    BookingCurrentStatusComponent,
    ReportComponent,
    ModalUnAuthorizedComponent,
    AdminCardComponent,
    ImportAccommodationComponent,
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
