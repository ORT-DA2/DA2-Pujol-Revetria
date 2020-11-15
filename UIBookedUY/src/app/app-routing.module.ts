import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccomodationsComponent } from './accomodations/accomodations.component';
import { BookingComponent } from './booking/booking.component';
import { LoginComponent } from './login/login.component';
import { RegionsComponent } from './regions/regions.component';
import { TouristicSpotsComponent } from './touristic-spots/touristic-spots.component';

const routes: Routes = [
  { path: '', component: RegionsComponent },
  { path: 'tourisitcSpots/:id', component: TouristicSpotsComponent},
  { path: 'accommodations/:id', component: AccomodationsComponent},
  { path: 'book/:id', component: BookingComponent},
  { path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{useHash: true})],
  exports: [RouterModule]
})

export class AppRoutingModule { }
