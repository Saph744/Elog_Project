import { Component, OnInit ,Injectable} from '@angular/core';
import { Router } from '@angular/router';
import { leavetype } from '../Models/leave/leavetype';
import { HolidayserviceComponent } from '../Services/holidayservice/holidayservice.component';

@Component({
  selector: 'app-leavesetting',
  templateUrl: './leavesetting.component.html',
  styleUrls: ['./leavesetting.component.scss']
})

@Injectable({
    providedIn: 'root'
})
export class LeavesettingComponent implements OnInit {

    constructor(private holidayService: HolidayserviceComponent, router:Router) { }

    p: number = 1;

    leavetype: leavetype[] = [];
    leavetypetoUpdate = {
        description:"",
    };

    leavetypetoInsert = {
        description: "",
    };


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
    }

    deleteLeave(LeaveType) {
        if (confirm('Leave Type Deleted Successfully')) {
            this.holidayService.deleteLeave(LeaveType.leaveTypeID).subscribe(() => {

                this.holidayService.GetAllLeaveType();
            },
                (err) => { console.log(err); }
            );
        }
    }

    editLeave(LeaveType) {
        this.leavetypetoUpdate = LeaveType;
    }
    addLeave(LeaveType) {
        this.leavetypetoInsert = LeaveType;
    }

    updateLeaveType() {
        if (confirm('Leave Type Updated Successfully')) {
            this.holidayService.editLeaveType(this.leavetypetoUpdate).subscribe(
                (resp) => {
                    console.log(resp);
                },
                (err) => {
                    console.log(err);
                });
        }
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
