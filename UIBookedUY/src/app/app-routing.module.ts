import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccomodationsComponent } from './accomodations/accomodations.component';
import { AdmAccomodationsComponent } from './adm-accomodations/adm-accomodations.component';
import { AdmAdministratorsComponent } from './adm-administrators/adm-administrators.component';
import { AdmBookingsComponent } from './adm-bookings/adm-bookings.component';
import { BookingStageCreationComponent } from './adm-bookings/booking-stage-creation/booking-stage-creation.component';
import { AuthGuard } from './authguard.service';
import { BookingComponent } from './booking/booking.component';
import { CreateReviewComponent } from './create-review/create-review.component';
import { CreateSpotComponent } from './create-spot/create-spot.component';
import { ImportAccommodationComponent } from './import-accommodation/import-accommodation.component';
import { LoginComponent } from './login/login.component';
import { RegionsComponent } from './regions/regions.component';
import { ReportComponent } from './report/report.component';
import { TouristicSpotsComponent } from './touristic-spots/touristic-spots.component';

const routes: Routes = [
  { path: '', component: RegionsComponent },
  { path: 'tourisitcSpots/:id', component: TouristicSpotsComponent},
  { path: 'accommodations/:id', component: AccomodationsComponent},
  { path: 'book/:id', component: BookingComponent},
  {path : 'create-review', component: CreateReviewComponent},
  {path : 'create-spot', canActivate:[AuthGuard], component: CreateSpotComponent},
  {path : 'adm-accommodation', canActivate:[AuthGuard], component: AdmAccomodationsComponent},
  {path : 'adm-administrators', canActivate:[AuthGuard], component: AdmAdministratorsComponent},
  {path : 'adm-bookings', canActivate:[AuthGuard], component: AdmBookingsComponent},
  {path : 'create-stage/:id', canActivate:[AuthGuard], component: BookingStageCreationComponent},
  {path : 'report', canActivate:[AuthGuard], component: ReportComponent},
  {path : 'import', canActivate:[AuthGuard], component: ImportAccommodationComponent},
  { path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{useHash: false})],
  exports: [RouterModule]
})

export class AppRoutingModule { }
