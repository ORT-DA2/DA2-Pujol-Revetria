import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AudioService } from '../audio-service.service';
import { AuthService } from '../auth.service';
import { AuthGuard } from '../authguard.service';
import {Howl, Howler} from 'howler';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  isAdmin: boolean = false;
  audioPLaying = false;

  constructor(private authService : AuthService, private route : Router,private audio : AudioService) {
  }

  ngOnInit(): void {
    if(this.authService.getToken()){
      this.isAdmin = true;
    }else{
      this.isAdmin = false;
    }
    this.authService.eventEmi.subscribe(res=>{
      this.isAdmin = res;
    });
  }

  public logOut(){
    this.authService.logOut();
    this.route.navigate(['/']);
  }

  muteAudio(){
    this.audio.mute();
    this.audioPLaying = false;
  }

  playAudio(){
    this.audio.playAudio()
    this.audioPLaying = true;
  }
}
