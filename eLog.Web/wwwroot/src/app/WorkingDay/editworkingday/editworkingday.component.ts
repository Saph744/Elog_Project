import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { workingday } from '../../Models/workingdays/workingdays.module';
import { WorkingdayService } from '../../Services/WorkingDays/workingday.service';


@Component({
  selector: 'app-editworkingday',
  templateUrl: './editworkingday.component.html',
  styleUrls: ['./editworkingday.component.scss']
})
export class EditworkingdayComponent implements OnInit {

    constructor(private route: ActivatedRoute, private workingdayService: WorkingdayService, private router: Router) { }

  workingdaydetails: workingday = {
    workingDayID: 0,
    hourPerDay: 0,
    description: '',
    isActive: false,
    companyID: 0,
    sun: false,
    mon: false,
    tue: false,
    wed: false,
    thu: false,
    fri: false,
    sat: false,
    createdBy: 0,
    createdTS: undefined
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        var workingDayID = params.get('id');

        if (workingDayID) {
          //call api
          this.workingdayService.GetWorkingDay(Number(workingDayID))
            .subscribe({
              next: (response) => {
                this.workingdaydetails = response;
              }
            })
        }
      }
    })
  }

  UpdateWorkingday() {
    if (confirm('Updated Successfully')) {
      this.workingdayService.UpdateWorkingday(this.workingdaydetails.workingDayID, this.workingdaydetails)
        .subscribe({
          next: (response) => {
            this.router.navigate(['workingdaylist']);
          }
        })
    }
  }

  DeleteWorkingday(workingDayID: number) {
    if (confirm('Deleted Successfully')) {
      this.workingdayService.DeleteWorkingday(workingDayID)
        .subscribe({
          next: (response) => {
            this.router.navigate(['workingdaylist']);
          }
        })
    }
  }

}
