import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AudioService } from '../audio-service.service';
import { AuthService } from '../auth.service';
import { AuthGuard } from '../authguard.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  isAdmin: boolean = false;

  eventEmitter = new EventEmitter<boolean>();

  constructor(private authService : AuthService, private route : Router,private audio : AudioService) { }

  ngOnInit(): void {
    if(localStorage.getItem('token')){
      this.isAdmin = true;
    }else{
      this.isAdmin = false;
    }
    this.authService.eventEmi.subscribe(res=>{
      this.isAdmin = res;
    });
  }

  printEvent(){
    console.log(this.isAdmin);
  }

  public logOut(){
    this.authService.logOut();
    this.route.navigate(['/']);
  }

  playAudio(){
    this.audio.playAudio()
  }
}
