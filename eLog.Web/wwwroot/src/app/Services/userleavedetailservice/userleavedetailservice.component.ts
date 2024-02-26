////import { HttpClient } from '@angular/common/http';
////import { Component, OnInit } from '@angular/core';
////import { Observable } from 'rxjs';
////import { environment } from '../../../environments/environment';
////import { userleavedetail } from '../../Models/leave/userleavedetail';

////@Component({
////  selector: 'app-userleavedetailservice',
////  template: `
////    <p>
////      userleavedetailservice works!
////    </p>
////  `,
////  styles: [
////  ]
////})
////export class UserleavedetailserviceComponent  {

////    baseApiUrl: string = environment.baseApiUrl;
////    constructor(private http: HttpClient) { }
////    GetAllUserLeave(): Observable<userleavedetail[]> {
////        return this.http.get<userleavedetail[]>(this.baseApiUrl + '/api/UserLeaveDetail/GetAllUserLeave')
////    }
////}
