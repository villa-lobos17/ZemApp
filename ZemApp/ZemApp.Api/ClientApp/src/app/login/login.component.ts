import { Component, OnInit } from '@angular/core';
import {HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  ngOnInit(): void {
    
  }

  public user : User;

  constructor(public httpClient: HttpClient) {
  	this.user = new User();
  }
 //terminator@gmail.com
  validateLogin() {
    this.httpClient.post("http://localhost:3907/api/Auth/Login",
    {
      "username":  this.user.username,
      "password":  this.user.password,
    },{responseType: 'text'})
    .subscribe(
    data  => {
      let token = JSON.parse(data)['token'];
      localStorage.setItem('token',token);
      let jwtData =localStorage.getItem('token').split('.')[1];
      let decodedJwtJsonData = window.atob(jwtData);
      let decodedJwtData = JSON.parse(decodedJwtJsonData);
      localStorage.setItem('role', decodedJwtData.role);
      localStorage.setItem('unique_name', decodedJwtData.unique_name);
      localStorage.setItem('nameid', decodedJwtData.nameid);
      location.reload();
    });
  }
}
export class User {
	constructor(){
		this.username = '';
		this.password = '';
	}
	public username;
	public password;
}