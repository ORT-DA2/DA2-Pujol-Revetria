import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccomodationsComponent } from './accomodations/accomodations.component';
import { AdmAccomodationsComponent } from './adm-accomodations/adm-accomodations.component';
import { AuthGuard } from './authguard.service';
import { BookingComponent } from './booking/booking.component';
import { CreateReviewComponent } from './create-review/create-review.component';
import { CreateSpotComponent } from './create-spot/create-spot.component';
import { LoginComponent } from './login/login.component';
import { RegionsComponent } from './regions/regions.component';
import { TouristicSpotsComponent } from './touristic-spots/touristic-spots.component';

const routes: Routes = [
  { path: '', component: RegionsComponent },
  { path: 'tourisitcSpots/:id', component: TouristicSpotsComponent},
  { path: 'accommodations/:id', component: AccomodationsComponent},
  { path: 'book/:id', component: BookingComponent},
  {path : 'create-review', component: CreateReviewComponent},
  {path : 'create-spot', canActivate:[AuthGuard], component: CreateSpotComponent},
  {path : 'adm-accommodation', canActivate:[AuthGuard], component: AdmAccomodationsComponent},
  { path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{useHash: false})],
  exports: [RouterModule]
})

export class AppRoutingModule { }
