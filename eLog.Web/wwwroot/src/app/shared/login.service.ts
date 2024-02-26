import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class LoginService {

    constructor(private myhttp: HttpClient) { }
    loginUrl: string = 'https://localhost:44398/api/User';
}
