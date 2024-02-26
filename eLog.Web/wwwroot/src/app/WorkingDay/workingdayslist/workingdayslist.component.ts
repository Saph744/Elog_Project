import { Component,  OnInit } from '@angular/core';
import { workingday } from 'app/Models/workingdays/workingdays.module';
import { WorkingdayService } from '../../Services/WorkingDays/workingday.service';

@Component({
  selector: 'app-workingdayslist',
  templateUrl: './workingdayslist.component.html',
  styleUrls: ['./workingdayslist.component.scss']
})
export class WorkingdayslistComponent implements OnInit {

    constructor(private workingdayService: WorkingdayService) { }
    p: number = 1;
    workingdays: workingday[] = [];
    ngOnInit(): void {
        this.workingdayService.GetAllWorkingdays()
            .subscribe({
                next: (workingdays) => {
                    this.workingdays = workingdays;
                },
                error: (response) => {
                    console.log(response);
                }
            })
    }
}
