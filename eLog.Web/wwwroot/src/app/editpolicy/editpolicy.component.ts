
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { leavepolicy } from '../Models/leave/leavepolicy';
import { leavepolicysetting } from '../Models/leave/leavepolicysetting';
import { HolidayserviceComponent } from '../Services/holidayservice/holidayservice.component';

@Component({
  selector: 'app-editpolicy',
  templateUrl: './editpolicy.component.html',
  styleUrls: ['./editpolicy.component.scss']
})
export class EditpolicyComponent implements OnInit {
    leave: any;
    leavepolicysetting: leavepolicysetting[]= [];
    p: number = 1;
    leavetypetoInsert = {
        description: "",
    };

    constructor(private holidayService: HolidayserviceComponent, private route: ActivatedRoute, private router: Router) { }

    ngOnInit(): void {
        this.route.paramMap.subscribe({
            next: (params) => {
                var leavepolicyID = params.get('leavePolicyID');

                if (leavepolicyID) {
                    //call api
                    this.holidayService.getLeavePolicyByID(Number(leavepolicyID))
                        .subscribe({
                            next: (response) => {
                                this.leave = response;
                            }
                        })
                }
            }
        })
        this.route.paramMap.subscribe({
            next: (params) => {
                var leavepolicyID = params.get('leavePolicyID');

                if (leavepolicyID) {
                    //call api
                    this.holidayService.getPolicyDataByID(Number(leavepolicyID))
                        .subscribe({
                            next: (leaveSetting) => {
                                this.leavepolicysetting = leaveSetting;
                            }
                        })
                }
            }
        })
    }
    EditPolicy() {
        if (confirm('Updated Successfully')) {
            this.holidayService.editLeavePolicy(this.leave.leavePolicyID, this.leave)
                .subscribe({
                    next: (response) => {
                        this.router.navigate(['/policyseting']);
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
