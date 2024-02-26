import { Component, OnInit } from '@angular/core';
import { Router } from 'express';
import {HolidayCalendar } from '../Models/holiday/holiday.module';
import { HolidayService } from '../Services/holiday.service';


@Component({
    selector: 'app-holiday',
    templateUrl: './holiday.component.html',
    styleUrls: ['./holiday.component.scss']
})
export class HolidayComponent implements OnInit {

    constructor() { }
    ngOnInit(): void {
  
  
    }
 
    
}
