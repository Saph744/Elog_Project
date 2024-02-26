import { Component, OnInit, Input } from '@angular/core';
import { HolidayService } from '../../Services/holiday.service';
import { HolidayCalendar } from '../../Models/holiday/holiday.module';
import { Router } from '@angular/router';
@Component({
    selector: 'app-add-edit-holiday',
    templateUrl: './add-edit-holiday.component.html',
    styleUrls: ['./add-edit-holiday.component.scss']
})
export class AddEditHolidayComponent implements OnInit {

    constructor(private holidayService: HolidayService, private router: Router) { }
    holidaycalendarviewmodel: HolidayCalendar = {
        holidayCalendarID: 0,
        calendarName: '',
        calendarYear: '',
        country: '',
    }

    ngOnInit(): void { 
    }
    InsertHolidayCalendar() {
        this.holidayService.InsertHolidayCalendar(this.holidaycalendarviewmodel)
            .subscribe({
                next: (HolidayCalendar) => {
                    this.router.navigate(['/holiday']);
                }
            })
    }
    
}
