import { Component, HostListener, OnDestroy } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'UIBookedUY';


  constructor(private auth: AuthService){}

  @HostListener('window:unload', [ '$event' ])
  unloadHandler(event) {
    this.auth.logOut();

  }

  playAudio(){
    let audio = new Audio();
    audio.src = "../../../assets/audio/w.mp3";
    audio.load();
    audio.play();
  }
}

