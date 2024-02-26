import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { EmployeeService } from "app/Services/EmployeeService/employee-service.service";
import { Employee } from "app/Models/employee/employee.module";
import { error } from "@angular/compiler/src/util";

@Component({
    selector: "app-user",
    templateUrl: "./user.component.html",
    styleUrls: ["./user.component.scss"],
})
export class UserComponent implements OnInit {
    p: number = 1;
    constructor(
        private employeeService: EmployeeService,
        private router: Router,
    ) { }

    employee: Employee[] = [];

    ngOnInit() {
        this.employeeService.GetAllEmployee().subscribe({
            next: (employee) => {
                this.employee = employee;
            },
            error: (response) => {
                console.log(response);
            },
        });
    }

    DeleteEmployee(Id : number) {
        if (confirm('Do you want to delete this record?')) {
            this.employeeService.DeleteEmployee(Id).subscribe((val) => {
               // this.toast.error('Sucess', 'Record Deleted');
                 this.ngOnInit();
                //this.employeeService.GetAllEmployee();
                this.router.navigate(['user']);
            }, (error) => {
                console.log(error)
            }
            );
        }
    }
}