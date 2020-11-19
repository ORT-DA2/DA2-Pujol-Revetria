import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AudioService {
  audio = new Audio();


  constructor() {
    this.audio.src = "../../../assets/audio/r2d2.mp3";
    this.audio.load();
  }

  playAudio(){
    this.audio.play();
  }
}
