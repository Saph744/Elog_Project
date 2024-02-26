import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    constructor(private router: Router, private http: HttpClient) { }
    invalidLogin: boolean;

    login(form: NgForm) {
        const credentials = {
            'username': form.value.username,
            'userpassword': form.value.userpassword
        }
        this.http.post("https://localhost:44398/api/auth/Login", credentials)
        .subscribe(response => {
          const token = (<any>response).token;
          localStorage.setItem("jwt", token);
          this.invalidLogin = false;
            this.router.navigate(['dashboard']);
        }, err => {
          this.invalidLogin = true;
        })
    }

  ngOnInit(): void {
  }

}
