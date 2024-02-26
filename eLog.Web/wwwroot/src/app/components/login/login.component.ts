import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    }
    loginForm = new FormGroup({
        username: new FormControl("", [Validators.required, Validators.email]),
        pwd: new FormControl("", [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(15),
        ]),
    });
    loginSubmited() {
        console.log(this.loginForm);
    }

    get UserName(): FormControl {
        return this.loginForm.get('username') as FormControl;
    }
    get Pwd(): FormControl {
        return this.loginForm.get('pwd') as FormControl;
    }
}
