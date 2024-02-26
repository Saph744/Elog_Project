import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeType } from '../Models/holiday/holiday.module';
import { HolidayService } from '../Services/holiday.service';

@Component({
  selector: 'app-employee-type',
  templateUrl: './employee-type.component.html',
  styleUrls: ['./employee-type.component.scss']
})
export class EmployeeTypeComponent implements OnInit { 

    p: number = 1;

    constructor(private holidayService: HolidayService, private router: Router) { }

    employeeType: EmployeeType = {
        employeeTypeID: 0,
        employeeTypes: ''
    }


    employeetype: EmployeeType[] = [];

    // for search
    employeeTypes: string;

    //for update
    employeeTypetoUpdate = {
        employeeTypes:"",
    }

    ngOnInit(): void {

        this.GetAllEmployeeType();
    }
    GetAllEmployeeType() {
        this.holidayService.GetAllEmployeeType()
            .subscribe({
                next: (employeetype) => {
                    this.employeetype = employeetype;
                },
                error: (response) => {
                    console.log(response);
                }
            })
    }


    InsertEmployeeType() {
        this.holidayService.InsertEmployeeType(this.employeeType)
            .subscribe({
                next: (EmployeeType) => {
                    this.router.navigate(['/employee-type']);
                    this.GetAllEmployeeType();
                }
            })
    }



    closeClick() {
        this.GetAllEmployeeType();
    }


    editClick(dataItem) {
        this.employeeTypetoUpdate = dataItem;
    }


    UpdateEmployeeType() {
        this.holidayService.UpdateEmployeeType(this.employeeTypetoUpdate)
            .subscribe((resp) => {
                console.log(resp);
            },
                (err) => {
                    console.log(err);
                });
    }

    DeleteEmployeeType(Id: number) {
        if (confirm('Are you sure want to delete??')) {
            this.holidayService.DeleteEmployeeType(Id)
                .subscribe(employeetype => {
                    alert("Holiday Calendar Deteted");
                    this.GetAllEmployeeType();

                })
        }
    }


    Search() {
        if (this.employeeTypes == "") {
            this.ngOnInit();
        } else {
            this.employeetype = this.employeetype.filter(res => {
                return res.employeeTypes.toLocaleLowerCase().match(this.employeeTypes.toLocaleLowerCase());
            })
        }
    }

    //for sorting
    key: string = 'employeeTypes';
    reverse: boolean = false;
    sort(key) {
        this.key = key;
        this.reverse = !this.reverse;

    }
}
