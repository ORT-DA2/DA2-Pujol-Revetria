import { Component, OnInit } from '@angular/core';
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

  adminNotFound = null;
  loginError = null;

  onClick(username: string, password : string): void {
    this.login(username,password);
  }

  public login(username: string, password:string){
    this.api.tryLogin(username,password).subscribe(response=>{
      localStorage.setItem('token',response.token);
      this.authservice.login();
      this.adminNotFound = null;
      this.loginError = null;
      this.route.navigate(['/']);
    }, error=>{
      if(error.status = 404){
        this.adminNotFound = error.error;
        this.loginError = null;
      }else{
        this.loginError = error.error;
        this.adminNotFound = null;
      }
      this.authservice.logOut();
    })
  }
}
