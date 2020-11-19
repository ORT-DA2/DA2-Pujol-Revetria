import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { APIService } from '../api.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private api : APIService, private authservice : AuthService, private route : Router) { }


  ngOnInit(): void {
  }

  onClick(username: string, password : string): void {
    this.login(username,password);
  }

  public login(username: string, password:string){
    //let login = this.authservice.login(username,password);
    this.api.tryLogin(username,password).subscribe(response=>{
      localStorage.setItem('token',response.token);
      this.authservice.login();
      this.route.navigate(['/']);
    }, error=>{
      this.authservice.logOut();
    })
    /*if(login){
      console.log(login);
      this.eventClicked.emit(true);
    }else{
      this.eventClicked.emit(false);
    }*/
  }
}
