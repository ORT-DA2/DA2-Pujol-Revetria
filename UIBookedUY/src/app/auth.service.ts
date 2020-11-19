import { EventEmitter, Injectable } from '@angular/core';
import { listeners } from 'process';
import { BehaviorSubject, Observable, Subscriber } from 'rxjs';
import { APIService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService{
    constructor(private api : APIService) {
    }

    eventEmi = new EventEmitter<boolean>();


  login() {
    this.eventEmi.emit(true);
  }

  getToken(){
    return localStorage.getItem('token');
  }

  isAuthenticated(){
    return localStorage.getItem('token') ? true : false;
  }

  logOut(){
    localStorage.removeItem("token");
    this.eventEmi.emit(false);
  }
}
