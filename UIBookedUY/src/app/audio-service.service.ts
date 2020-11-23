import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AudioService {
  audio = new Audio();


  constructor() {
    this.audio.src = "../../../assets/audio/ambient.mp3";
    this.audio.load();
    this.audio.volume = 0.1;
    this.audio.loop = true;
  }

  mute(){
    this.audio.volume = 0;
  }

  playAudio(){
    this.audio.play();
    this.audio.volume = 0.1;
  }
}
