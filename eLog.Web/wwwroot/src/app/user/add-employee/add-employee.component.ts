import { Component, OnInit } from "@angular/core";
import { Company, Department, Employee, EmployeeType, LeavePolicy } from "app/Models/employee/employee.module";
import { EmployeeService } from "app/Services/EmployeeService/employee-service.service";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";


@Component({
    selector: "app-add-employee",
    templateUrl: "./add-employee.component.html",
    styleUrls: ["./add-employee.component.scss"],
})
export class AddEmployeeComponent implements OnInit {
    constructor(private employeeService: EmployeeService, private router: Router) { }

    viewEmployee: Employee = {
        username: '',
        emailAddress: '',
        firstname: '',
        middleName: '',
        lastname: '',
        designation: '',
        address1: '',
        address2: '',
        state: 0,
        countryCode: '',
        country: '',
        contactNumber: '',
        gender: '',
        companyID: 0,
        employeeID: 0,
        contactID: 0,
        departmentID: 0,
        departmentName: '',
        locationID: 0,
        location: '',
        employeeTypeID: 0,
        employeeTypes: '',
        employeeStatus: 0,
        employeeManager: '',
        workingDayType: '',
        leavePolicyID: 0,
        description: '',
        leaveApprovedBy: '',
        HolidayName: '',
        dateOfBirth: new Date(),
        joinedDate: new Date()
    }

    viewDepartment: Department[] = [];
    viewEmployeeType: EmployeeType[] = [];
    viewLeavePolicy: LeavePolicy[] = [];
    viewLocation: Location[] = [];
    viewCompany: Company[] = [];

    ngOnInit() {
        /*        this.employeeService.GetAllCompany().subscribe({
                    next: (viewCompany) => {
                        this.viewCompany = viewCompany;
                    },
                    error: (response) => {
                        console.log(response);
                    },
                });
        
                //get department details
                this.employeeService.GetAllDepartmentDetails().subscribe({
                    next: (viewDepartment) => {
                        this.viewDepartment = viewDepartment;
                    },
                    error: (response) => {
                        console.log(response);
                    },
                });
        
                //location
                this.employeeService.GetAllLocation().subscribe({
                    next: (viewLocation) => {
                        this.viewLocation = viewLocation;
                    },
                    error: (response) => {
                        console.log(response);
                    },
                });
        
                //get employeeType details
                this.employeeService.GetAllEmployeeType().subscribe({
                    next: (viewEmployeeType) => {
                        this.viewEmployeeType = viewEmployeeType;
                    },
                    error: (response) => {
                        console.log(response);
                    },
                });
        
                //get Leavepolicy details
                this.employeeService.GetAllLeavePolicy().subscribe({
                    next: (viewLeavePolicy) => {
                        this.viewLeavePolicy = viewLeavePolicy;
                    },
                    error: (response) => {
                        console.log(response);
                    },
                });
            }*/
    }
    InsertEmployee() {
        this.employeeService.InsertEmployee(this.viewEmployee).subscribe((data) => {
            //this.toast.success('Sucess', 'Record Inserted');
            alert('Employee Inserted Successfully'); 
            this.resetForm();
            this.router.navigate(['/user']);
        })
    }

    resetForm(form?: NgForm) {
        if (form != null)
            form.resetForm();
    }
}