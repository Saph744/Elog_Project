import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Department } from '../Models/department/department/department.module';

@Injectable({
    providedIn: 'root'
})
export class DepartmentService {
    readonly APIUrl = "https://localhost:44398/api"

    constructor(private http: HttpClient) { }

    GetAllDepartmentDetails(): Observable<Department[]> {
        return this.http.get<Department[]>(this.APIUrl + '/Department/GetAllDepartmentDetails')
    }

    GetDepartmentByID(Id: number): Observable<Department[]> {
        return this.http.get<Department[]>(this.APIUrl + '/Department/GetDepartmentByID/?departmentID=' + Id)
    }

    InsertDepartment(viewDepartment: Department): Observable<Department> {
        viewDepartment.departmentID = 0;
        return this.http.post<Department>(this.APIUrl + '/Department/InsertDepartment', viewDepartment);
    }
    UpdateDepartmentDetails(dataItem): Observable<Department> {
        return this.http.put<Department>(this.APIUrl + '/Department/UpdateDepartmentDetails', dataItem);
    }
    DeleteDepartment(Id: number): Observable<Department> {
        return this.http.delete<Department>(this.APIUrl + '/Department/DeleteDepartment?Id=' + Id);
    }
}
