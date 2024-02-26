import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { leavepolicy } from '../Models/leave/leavepolicy';
import { HolidayserviceComponent } from '../Services/holidayservice/holidayservice.component';

@Component({
  selector: 'app-policysetting',
  templateUrl: './policysetting.component.html',
  styleUrls: ['./policysetting.component.scss']
})
export class PolicysettingComponent implements OnInit {

    constructor(private holidayService: HolidayserviceComponent, router: Router) { }

    p: number = 1;

   leavepolicy: leavepolicy[] = [];

    ngOnInit(): void {
        this.holidayService.GetAllLeavePolicy()
            .subscribe({
                next: (leavePolicy) => {
                    this.leavepolicy = leavePolicy;
                },
                error: (response) => {
                    console.log(response);
                }
            })
    }
    deletePolicy(LeavePolicy) {
        if (confirm('Leave Type Deleted Successfully')) {
            this.holidayService.deletePolicy(LeavePolicy.leavePolicyID).subscribe(() => {

                this.holidayService.GetAllLeavePolicy();
            },
                (err) => { console.log(err); }
            );
        }
    }
   
}

