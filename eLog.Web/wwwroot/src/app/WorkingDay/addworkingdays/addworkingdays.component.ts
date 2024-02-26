import { Component, OnInit } from '@angular/core';
import { WorkingdayService } from 'app/Services/WorkingDays/workingday.service';
import { Router } from '@angular/router';
import { workingday } from 'app/Models/workingdays/workingdays.module';

@Component({
  selector: 'app-addworkingdays',
  templateUrl: './addworkingdays.component.html',
  styleUrls: ['./addworkingdays.component.scss']
})
export class AddworkingdaysComponent implements OnInit {

  constructor(private workingdayService: WorkingdayService, private router: Router) { }
  workingDayViewModel: workingday = {
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
  }
  Insertworkingday() {
    if (confirm('Added Successfully')) {
        this.workingdayService.Insertworkingday(this.workingDayViewModel)
            .subscribe({
                next: (workingday) => {
                    this.router.navigate(['workingdayslist']);
                }
            })
    }
}

}
