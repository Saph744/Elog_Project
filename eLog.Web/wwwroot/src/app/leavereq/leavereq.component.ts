
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { employee } from '../Models/employee';
import { leave } from '../Models/leave/leave';
import { leavetype } from '../Models/leave/leavetype';
import { HolidayserviceComponent } from '../Services/holidayservice/holidayservice.component';
 
@Component({
  selector: 'app-leavereq',
  templateUrl: './leavereq.component.html',
  styleUrls: ['./leavereq.component.scss']
})
export class LeavereqComponent {

    constructor(private holidayService: HolidayserviceComponent,  private router: Router) { }
    leavetype: leavetype[] = [];
    employee: employee[] = [];

    leaveRequest: leave = {
        leaveApprovalID: 0,
        companyID: 0,
        startDate: new Date,
        endDate: new Date,
        daysOff: 0,
        hourOff: 0,
        leavePolicyID: 0,
        leaveReason: '',
        approvalStatus: '',
        noticePeriod: 0,
        employeeID: 0,
        leaveTypeID: 0,
        createdBy: 0,
        createdTS: new Date,

        description: '',
        firstname: '',
        middleName: '',
        lastname: '',
        contactID:0,
    }

    ngOnInit(): void {
        this.holidayService.GetAllLeaveType()
            .subscribe({
                next: (leaveType) => {
                    this.leavetype = leaveType;
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
 
  /*  InsertLeaveReq() {
        if (confirm('Added Successfully')) {
            this.holidayService.LeaveReqInsert(this.leaveRequest)
                .subscribe({
                    next: (leave) => {
                        this.router.navigate(['/leavereq']);
                    }
                })
        }
    }*/

    InsertLeaveReq() {
        if (confirm('Leave Request Submitted Successfully')) {
            this.holidayService.LeaveReqInsert(this.leaveRequest).subscribe(
                (resp) => {
                    console.log(resp);
                },
                (err) => {
                    console.log(err);
                });
        }

    }

   
   


}
