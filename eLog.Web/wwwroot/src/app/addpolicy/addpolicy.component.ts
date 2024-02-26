import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { leavepolicy } from '../Models/leave/leavepolicy';
import { leavetype } from '../Models/leave/leavetype';
import { HolidayserviceComponent } from '../Services/holidayservice/holidayservice.component';

@Component({
  selector: 'app-addpolicy',
  templateUrl: './addpolicy.component.html',
  styleUrls: ['./addpolicy.component.scss']
})
export class AddpolicyComponent implements OnInit {

    constructor(private holidayService: HolidayserviceComponent, private route: ActivatedRoute, private router: Router) { }

    leavePolicy: leavepolicy = {
        leavePolicyID: 0,
        companyID: 0,
        description:'',
        createdBy: 0,
        createdTS: undefined,
    }
    leavetypetoInsert = {
        description: "",
    };

    leavetype: leavetype[] = [];

    ngOnInit(): void {
        this.holidayService.GetAllLeaveType()
            .subscribe({
                next: (LeaveType) => {
                    this.leavetype = LeaveType;
                },
                error: (response) => {
                    console.log(response);
                }
            })
  }
    InsertPolicy() {
        if (confirm('Added Successfully')) {
            this.holidayService.insertleavePolicy(this.leavePolicy)
                .subscribe({
                    next: (leavepolicy) => {
                        this.router.navigate(['/policysetting']);
                    }
                })
        }
    }
    addLeave(LeaveType) {
        this.leavetypetoInsert = LeaveType;
    }
    addLeaveType(LeaveType) {
        if (confirm('Leave Type Added Successfully')) {
            this.holidayService.insertleaveType(this.leavetypetoInsert).subscribe(
                (resp) => {
                    console.log(resp);
                    LeaveType.reset();
                    this.reloadCurrentPage();
                },
                (err) => {
                    console.log(err);
                });
        }

    }
    reloadCurrentPage() {
        window.location.reload();
    }
}
