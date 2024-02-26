import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HolidayCalendar } from '../../Models/holiday/holiday.module';
import { HolidayService } from '../../Services/holiday.service';

@Component({
    selector: 'app-show-delete-holiday',
    templateUrl: './show-delete-holiday.component.html',
    styleUrls: ['./show-delete-holiday.component.scss']
})
export class ShowDeleteHolidayComponent implements OnInit {
    p: number = 1;

    constructor(private holidayService: HolidayService, private router: Router) { }
    holidaycalendarviewmodel: HolidayCalendar = {
        holidayCalendarID: 0,
        calendarName: '',
        calendarYear: '',
        country: '',
    }
    

    //For search
    calendarName: string;


    holidaycalendar: HolidayCalendar[] = [];

    dataItemtoUpdate = {
        calendarName:"",
    }

    ModelTitle: string;
    ActivateAddEditHolidayCom: boolean = false;
    hol: any;


    ngOnInit(): void {
      
        this.GetAllHolidayCalendar();
    }
    GetAllHolidayCalendar() {
        this.holidayService.GetAllHolidayCalendar()
            .subscribe({
                next: (holidaycalendar) => {
                    this.holidaycalendar = holidaycalendar;
                },
                error: (response) => {
                    console.log(response);
                }
            })
    }
   


    addClick() {
        this.hol = {
            CalendarName: "",
            Country: ""
        }
        this.ModelTitle = "Holiday Type Information";
        this.ActivateAddEditHolidayCom = true;

    }

    editClick(dataItem) {
        this.ModelTitle = "Edit Holiday Type Information";
        this.dataItemtoUpdate = dataItem;
        
       
    } 

    UpdateHolidayCalendar() {
        this.holidayService.UpdateHolidayCalendar(this.dataItemtoUpdate)
            .subscribe((resp) => {
                console.log(resp);
            },
                (err) => {
                    console.log(err);
                });
    }


    DeleteHolidayCalendar(Id: number) {
        if (confirm('Are you sure want to delete??')) {
            this.holidayService.DeleteHolidayCalendar(Id)
                .subscribe(holidaycalendarviewmodel => {
                    alert("Holiday Calendar Deteted");
                    this.GetAllHolidayCalendar();
                 
                })
        }
    }

    closeClick() {
        this.ActivateAddEditHolidayCom = false;
        this.GetAllHolidayCalendar();
    }


    Search() {
        if (this.calendarName == "") {
            this.ngOnInit();
        } else {
            this.holidaycalendar = this.holidaycalendar.filter(res => {
                return res.calendarName.toLocaleLowerCase().match(this.calendarName.toLocaleLowerCase());
            })
        }
    }

    key: string = 'calendarName';
    reverse: boolean = false;
    sort(key) {
        this.key = key;
        this.reverse = !this.reverse;

    }
}


          