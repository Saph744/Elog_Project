import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Company, Contact, Department, Employee, EmployeeType } from '../../Models/employee/employee.module';
import { leavepolicy } from '../../Models/leave/leavepolicy';
@Injectable({
    providedIn: 'root'
})

export class EmployeeService {


    constructor(private http: HttpClient) { }

    baseApiUrl: string = environment.baseApiUrl;

    //company
    GetAllCompany(): Observable<Company[]> {
        return this.http.get<Company[]>(this.baseApiUrl + '/api/Company/GetAllCompany')
    }
    //Contact ->GetByID
    GetContactByID(Id: number): Observable<Contact[]> {
        return this.http.get<Contact[]>(this.baseApiUrl + '/api/Contact/GetByID/?Id=' + Id);
    }
    DeleteContact(Id: number): Observable<Contact[]> {
        return this.http.delete<Contact[]>(this.baseApiUrl + '/api/Contact/DeleteContact/?Id=' + Id);
    }
    //location
    GetAllLocation(): Observable<Location[]> {
        return this.http.get<Location[]>(this.baseApiUrl + '/api/Location/GetAllLocationData');
    }
    //employeeType
    GetAllEmployeeType(): Observable<EmployeeType[]> {
        return this.http.get<EmployeeType[]>(this.baseApiUrl + '/api/EmployeeType/GetAllEmployeeType');
    }
    GetEmployeeTypeByID(Id: number): Observable<EmployeeType[]> {
        return this.http.get<EmployeeType[]>(this.baseApiUrl + '/api/EmployeeType/GetEmployeeTypeByID/?Id=' + Id);
    }
    //department
    GetAllDepartmentDetails(): Observable<Department[]> {
        return this.http.get<Department[]>(this.baseApiUrl + '/api/Department/GetAllDepartmentDetails');
    }
    GetDepartmentByID(Id: number): Observable<Department[]> {
        return this.http.get<Department[]>(this.baseApiUrl + '/api/Department/GetDepartmentByID/?Id=' + Id);
    }
    //LeavePolicy
    GetAllLeavePolicy(): Observable<leavepolicy[]> {
        return this.http.get<leavepolicy[]>(this.baseApiUrl + '/api/LeavePolicy/GetAllLeavePolicy')
    }
    getLeavePolicyByID(leavePolicyID): Observable<leavepolicy[]> {
        return this.http.get<leavepolicy[]>(this.baseApiUrl + '/api/LeavePolicy/GetLeavePolicyByID?LeavePolicyID=' + leavePolicyID)
    }

    //Employee
    GetAllEmployee(): Observable<Employee[]> {
        return this.http.get<Employee[]>(this.baseApiUrl + '/api/Employee/GetAllEmployee');
    }
    GetEmployeeByID(Id: number): Observable<Employee> {
        return this.http.get<Employee>(this.baseApiUrl + '/api/Employee/GetEmployeeBYID/?Id=' + Id);
    }
    InsertEmployee(viewEmployee: Employee): Observable<Employee> {
        return this.http.post<Employee>(this.baseApiUrl + '/api/Employee/InsertEmployee', viewEmployee);
    }
    saveEmployee(viewEmployee) {
        return this.http.post(this.baseApiUrl, viewEmployee);
    }
    UpdateEmployee(viewEmployee: Employee): Observable<Employee> {
        return this.http.put<Employee>(this.baseApiUrl + '/api/Employee/UpdateEmployee', viewEmployee);
    }
    DeleteEmployee(Id: number): Observable<Employee[]> {
        return this.http.delete<Employee[]>(this.baseApiUrl + '/api/Employee/DeleteEmployee?Id=' + Id);
    }

    //image // Returns an observable
    upload(file, contactID): Observable<any> {
        const formData = new FormData();
        var name = contactID;
        // Store form name as "file" with file data
        formData.append("file", file, name);
        // formData.append('ContactID', contactID);
        // Make http post request over api with formData as req
        return this.http.post<any>(this.baseApiUrl + '/api/Employee/UploadFiles', formData);
    }
}