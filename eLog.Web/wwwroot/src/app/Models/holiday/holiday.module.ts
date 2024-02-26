export interface HolidayCalendar {
    holidayCalendarID: number;
    calendarName: string;
    calendarYear: string;
    country: string;
}

export interface HolidayDetail {
    holidayDetailID: number;
    holidayYear: number;
    holidayDate: Date;
    description: string;
    holidayName: string;
}

export interface EmployeeType {
    employeeTypeID: number;
    employeeTypes: string;
} 