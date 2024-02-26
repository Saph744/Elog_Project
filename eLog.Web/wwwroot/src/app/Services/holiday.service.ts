
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeType, HolidayCalendar, HolidayDetail } from '../Models/holiday/holiday.module';

@Injectable({
  providedIn: 'root'
})
export class HolidayService {
    readonly APIUrl = "https://localhost:44398/api"


    constructor(private http: HttpClient) { }
    //For HolidayCalendar
    GetAllHolidayCalendar(): Observable<HolidayCalendar[]> {
        return this.http.get<HolidayCalendar[]>(this.APIUrl + '/HolidayCalendar/GetAllHolidayCalendar')
    }

    GetByHolidayCalendarId(Id: number): Observable<HolidayCalendar[]> {
        return this.http.get<HolidayCalendar[]>(this.APIUrl + '/HolidayCalendar/GetByHolidayCalendarId/?holidayCalendarID=' + Id)
    }

    InsertHolidayCalendar(holidaycalendarviewmodel: HolidayCalendar): Observable<HolidayCalendar> {
        holidaycalendarviewmodel.holidayCalendarID = 0;
        return this.http.post<HolidayCalendar>(this.APIUrl + '/HolidayCalendar/InsertHolidayCalendar', holidaycalendarviewmodel);
    }
    UpdateHolidayCalendar(dataItem): Observable<HolidayCalendar> {
        return this.http.put<HolidayCalendar>(this.APIUrl + '/HolidayCalendar/UpdateHolidayCalendar', dataItem);
    }
    DeleteHolidayCalendar(Id: number): Observable<HolidayCalendar> {
        return this.http.delete<HolidayCalendar>(this.APIUrl + '/HolidayCalendar/DeleteHolidayCalendar?Id=' + Id);
    }

    //for HolidayDetails
    GetAllHoliday(): Observable<HolidayDetail[]> {
        return this.http.get<HolidayDetail[]>(this.APIUrl + '/HolidayDetail/GetAllHoliday')
    }

    GetHolidayDetail(Id: number): Observable<HolidayDetail[]> {
        return this.http.get<HolidayDetail[]>(this.APIUrl + '/HolidayDetail/GetHolidayDetail/?holidayDetailID=' + Id)
    }

    InsertHoliday(holidayDetail: HolidayDetail): Observable<HolidayDetail> {
        holidayDetail.holidayDetailID = 0;
        return this.http.post<HolidayDetail>(this.APIUrl + '/HolidayDetail/InsertHoliday', holidayDetail);
    }
    UpdateHoliday(holDetail): Observable<HolidayDetail> {
        return this.http.put<HolidayDetail>(this.APIUrl + '/HolidayDetail/UpdateHoliday', holDetail);
    }
    DeleteHoliday(Id: number): Observable<HolidayDetail> {
        return this.http.delete<HolidayDetail>(this.APIUrl + '/HolidayDetail/DeleteHoliday?Id=' + Id);
    }

    //for EmployeeTypes
    GetAllEmployeeType(): Observable<EmployeeType[]> {
        return this.http.get<EmployeeType[]>(this.APIUrl + '/EmployeeType/GetAllEmployeeType')
    }

    GetEmployeeTypeByID(Id: number): Observable<EmployeeType[]> {
        return this.http.get<EmployeeType[]>(this.APIUrl + '/EmployeeType/GetEmployeeTypeByID/?employeeTypeID=' + Id)
    }

    InsertEmployeeType(viewEmployeeType: EmployeeType): Observable<EmployeeType> {
        viewEmployeeType.employeeTypeID = 0;
        return this.http.post<EmployeeType>(this.APIUrl + '/EmployeeType/InsertEmployeeType', viewEmployeeType);
    }
    UpdateEmployeeType(employeeTypetoUpdate): Observable<EmployeeType> {
        return this.http.put<EmployeeType>(this.APIUrl + '/EmployeeType/UpdateEmployeeType', employeeTypetoUpdate);
    }
    DeleteEmployeeType(Id: number): Observable<EmployeeType> {
        return this.http.delete<EmployeeType>(this.APIUrl + '/EmployeeType/DeleteEmployeeType?Id=' + Id);
    }
}
