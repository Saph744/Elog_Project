import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { HolidayDetail } from '../Models/holiday/holiday.module';
import { HolidayService } from '../Services/holiday.service';

@Component({
    selector: 'app-holiday-list',
    templateUrl: './holiday-list.component.html',
    styleUrls: ['./holiday-list.component.scss']
})
export class HolidayListComponent implements OnInit {

    years = ['2022', '2023']

    p: number = 1;


    constructor(private holidayService: HolidayService, private router: Router) { }
    holidayDetail: HolidayDetail = {
        holidayDetailID: 0,
        holidayYear: 0,
        holidayDate: undefined,
        description: '',
        holidayName: ''
    }


    holidaydetail: HolidayDetail[] = [];

    //For search
    holidayName: string;


    //for update
    holDetailtoUpdate = {
        holidayDate: "",
        holidayName: "",
        holidayYear: "",
    }

    ngOnInit(): void {


        this.GetAllHoliday();

    }


    GetAllHoliday() {
        this.holidayService.GetAllHoliday()
            .subscribe({
                next: (holidaydetail) => {
                    this.holidaydetail = holidaydetail;
                },
                error: (response) => {
                    console.log(response);
                }
            })
    }


    InsertHoliday() {
        this.holidayService.InsertHoliday(this.holidayDetail)
            .subscribe({
                next: (HolidayDetail) => {
                    this.router.navigate(['/holiday-list']);
                    this.GetAllHoliday();
                }
            })
    }

    DeleteHoliday(Id: number) {
        if (confirm('Are you sure want to delete??')) {
            this.holidayService.DeleteHoliday(Id)
                .subscribe(holidaydetail => {
                    alert("Holiday Calendar Deteted");
                    this.GetAllHoliday();

                })
        }
    }

    closeClick() {
        this.GetAllHoliday();
    }

    editClick(holDetail) {
        this.holDetailtoUpdate = holDetail;
    }

    UpdateHoliday() {
        this.holidayService.UpdateHoliday(this.holDetailtoUpdate)
            .subscribe((resp) => {
                console.log(resp);
            },
                (err) => {
                    console.log(err);
                });
    }

    //for searching
    Search() {
        if (this.holidayName == "") {
            this.ngOnInit();
        } else {
            this.holidaydetail = this.holidaydetail.filter(res => {
                return res.holidayName.toLocaleLowerCase().match(this.holidayName.toLocaleLowerCase());
            })
        }
    }

    //for sorting
    key: string = 'holidayYear';
    reverse: boolean = false;
    sort(key) {
        this.key = key;
        this.reverse = !this.reverse;

    }



}
