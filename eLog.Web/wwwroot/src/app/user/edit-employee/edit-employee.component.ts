import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from "app/Services/EmployeeService/employee-service.service";
import { Company, Contact, Department, Employee, EmployeeType, LeavePolicy } from '../../Models/employee/employee.module';


@Component({
    selector: 'app-edit-employee',
    templateUrl: './edit-employee.component.html',
    styleUrls: ['./edit-employee.component.scss']
})
export class EditEmployeeComponent implements OnInit {

    FilePath: '';
    //loading: boolean = false;
    file: File = null;

    employeeDetails: Employee = {
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
    viewContact: Contact[] = [];
    viewLeavePolicy: LeavePolicy[] = [];
    viewLocation: Location[] = [];
    viewCompany: Company[]=[];
    constructor(private route: ActivatedRoute, private employeeService: EmployeeService, private router: Router) { }

    ngOnInit(): void {
         this.employeeService.GetAllCompany().subscribe({
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
         //getbyleavepolicyid
         this.route.paramMap.subscribe({
             next: (params) => {
                 var leavePolicyID = params.get('leavePolicyID');
 
                 if (leavePolicyID) {
                     //call api
                     this.employeeService.getLeavePolicyByID(Number(leavePolicyID))
                         .subscribe({
                             next: (response) => {
                                 this.viewLeavePolicy = response;
                             }
                         })
                 }
             }
         })
        //getbyEmployeeid
        this.route.paramMap.subscribe({
            next: (params) => {
                var Id = params.get('Id');

                if (Id) {
                    //call api
                    this.employeeService.GetEmployeeByID(Number(Id))
                        .subscribe({
                            next: (response) => {
                                this.employeeDetails = response;
                            }
                        })
                }
            }
        })
    }
    UpdateEmployee() {
        if (confirm('Updated Successfully')) {
            this.employeeService.UpdateEmployee(this.employeeDetails)
                .subscribe({
                    next: (response) => {
                        this.router.navigate(['/user']);
                    }
                })
        }
    }
    //image upload
    handleFileInput( file: any) {
        this.file = file.item(0);
        //show image preview
        var reader = new FileReader();
        reader.onload = (event: any) => {
            this.FilePath = event.target.result;
        }
        reader.readAsDataURL(this.file);
    }

    onUpload() {
        this.employeeService.upload(this.file,this.employeeDetails.contactID).subscribe(
            (response) => {
                console.log(response);
                this.employeeDetails.contactID = response;
            },
            (error) => {
                console.log(error);
            }
        );
    }
}
