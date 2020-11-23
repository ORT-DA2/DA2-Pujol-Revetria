import { Component, HostListener, OnDestroy } from '@angular/core';
import { NgxHowlerService } from 'ngx-howler/public-api';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  {
  title = 'UIBookedUY';


  constructor(private auth: AuthService){
  }

  @HostListener('window:unload', [ '$event' ])
  unloadHandler(event) {
    this.auth.logOut();
  }
}

