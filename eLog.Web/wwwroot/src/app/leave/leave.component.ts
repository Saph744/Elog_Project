import { Component, OnInit } from '@angular/core';
import { employee } from '../Models/employee';
import { holiday } from '../Models/holiday/holiday';
import { leave } from '../Models/leave/leave';
import { userleavedetail } from '../Models/leave/userleavedetail';
import { HolidayserviceComponent } from '../Services/holidayservice/holidayservice.component';

@Component({
  selector: 'app-leave',
  templateUrl: './leave.component.html',
  styleUrls: ['./leave.component.scss']
})
export class LeaveComponent implements OnInit {

    p: number = 1;

    constructor(private holidayService: HolidayserviceComponent ) { }
    holiday: holiday[] = [];
    userleavedetail: userleavedetail[] = [];
    leave:leave[]=[];
    employee:employee[]=[];

    ngOnInit(): void {
        this.holidayService.GetAllHoliday()
            .subscribe({
                next: (holiday) => {
                    this.holiday = holiday;
                },
                error: (response) => {
                    console.log(response);
                }
            })
        this.holidayService.GetAllUserLeave()
            .subscribe({
                next: (userLeaveDetail) => {
                    this.userleavedetail = userLeaveDetail;
                },
                error: (response) => {
                    console.log(response);
                }
            })
        this.holidayService.GetAllLeaveApp()
            .subscribe({
                next: (leaveapproval) => {
                    this.leave = leaveapproval;
                },
                error: (response) => {
                    console.log(response);
                }
            })
        this.holidayService.GetAllData()
            .subscribe({
                next: (employee) => {
                    this.employee = employee;
                },
                error: (response) => {
                    console.log(response);
                }
            })
        
        
    }
   



}
