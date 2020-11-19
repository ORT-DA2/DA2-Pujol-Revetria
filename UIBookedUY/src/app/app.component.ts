import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'UIBookedUY';

  playAudio(){
    let audio = new Audio();
    audio.src = "../../../assets/audio/w.mp3";
    audio.load();
    audio.play();
  }
}

