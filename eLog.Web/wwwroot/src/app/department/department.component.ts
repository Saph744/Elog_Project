import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Department } from '../Models/department/department/department.module';
import { DepartmentService } from '../Services/department.service';

@Component({
    selector: 'app-department',
    templateUrl: './department.component.html',
    styleUrls: ['./department.component.scss']
})
export class DepartmentComponent implements OnInit {

    constructor(private departmentService: DepartmentService, private router: Router) { }
    department: Department = {
        departmentID: 0,
        departmentName: '',
        companyID: 0
    }


    departMent: Department[] = [];

    //for pagination
    p: number = 1;

    //For search
    departmentName: string;

    /*for update*/
    depUpdate = {
        departmentName: ""
    }

    ngOnInit(): void {
        this.GetAllDepartmentDetails();
    }

    GetAllDepartmentDetails() {
        this.departmentService.GetAllDepartmentDetails()
            .subscribe({
                next: (departMent) => {
                    this.departMent = departMent;
                },
                error: (response) => {
                    console.log(response);
                }
            })
    }

    InsertDepartment() {
        this.departmentService.InsertDepartment(this.department)
            .subscribe({
                next: (Department) => {
                    this.router.navigate(['/department']);
                    this.GetAllDepartmentDetails();
                }
            })
    }


    closeClick() {
        this.GetAllDepartmentDetails();
    }

    editClick(department) {
        this.depUpdate = department;
    }

    UpdateDepartment() {
        this.departmentService.UpdateDepartmentDetails(this.depUpdate)
            .subscribe((resp) => {
                console.log(resp);
            },
                (err) => {
                    console.log(err);
                });
    }


    DeleteDepartment(Id: number) {
        if (confirm('Are you sure want to delete??')) {
            this.departmentService.DeleteDepartment(Id)
                .subscribe(departMent => {
                    alert("Holiday Calendar Deteted");
                    this.GetAllDepartmentDetails();

                })
        }
    }

    //for searching
    Search() {
        if (this.departmentName == "") {
            this.ngOnInit();
        } else {
            this.departMent = this.departMent.filter(res => {
                return res.departmentName.toLocaleLowerCase().match(this.departmentName.toLocaleLowerCase());
            })
        }
    }
    //for sorting
    key: string = 'departmentName';
    reverse: boolean = false;
    sort(key) {
        this.key = key;
        this.reverse = !this.reverse;

    }

}
