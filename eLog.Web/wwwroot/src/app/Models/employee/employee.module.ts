export interface Employee {
    username: string;
    emailAddress: string;
    firstname: string;
    middleName: string;
    lastname: string;
    designation: string;
    address1: string;
    address2: String;
    state: number;
    countryCode: string;
    country: string;
    contactNumber: string;
    gender: string;
    companyID: number;
    employeeID: number;
    contactID: number;
    departmentID: number;
    departmentName: string;
    locationID: number;
    location: string;
    employeeTypeID: number;
    employeeTypes: String;
    employeeStatus: number;
    employeeManager: string;
    workingDayType: string;
    leavePolicyID: number;
    description: string;
    leaveApprovedBy: string;
    HolidayName: string;
    dateOfBirth: Date;
    joinedDate: Date;
}

export class Department  {
    departmentID: number = 0;
    departmentName: string =''
}

export class EmployeeType {
    employeeTypeID: number = 0;
    employeeTypes: string = ''
}

export class Contact {
    contactID: number = 0;
    emailAddress: string = '';
    address1: string = '' ;
    address2: String = '' ;
    contactNumber: string = '';
    fileName: string = '';
    filePath: string = '';
}

export class LeavePolicy {
    leavePolicyID: number = 0;
    description: string = '';
}

export class Location {
    locationID: number = 0;
    locationName: string = '';
}

export class Company{
    companyID: number = 0;
    state: string = '';
    country: string = '';
    countryCode: string = '';
}