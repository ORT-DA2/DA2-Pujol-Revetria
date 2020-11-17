import { Component, OnInit } from '@angular/core';
import { APIService } from '../api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private api : APIService) { }

  ngOnInit(): void {
  }

  public login(username: string, password:string){
    this.api.tryLogin(username,password).subscribe(response=>{
      console.log(response);
      console.log("good")
    },error=>{
      console.log(error);
    })
  }
}
