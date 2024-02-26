import { Routes } from '@angular/router';
import { AddcompanyComponent } from '../../addcompany/addcompany.component';
import { CompanylistComponent } from '../../companylist/companylist.component';
import { UserComponent } from 'app/user/user.component';
import { AddEmployeeComponent } from 'app/user/add-employee/add-employee.component';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { HolidayComponent } from '../../holiday/holiday.component';
import { HolidayListComponent } from '../../holiday-list/holiday-list.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { EmployeeTypeComponent } from '../../employee-type/employee-type.component';
import { LeaveComponent } from '../../leave/leave.component';
import { EditEmployeeComponent } from '../../user/edit-employee/edit-employee.component';
import { LeavereqComponent } from '../../leavereq/leavereq.component';
import { LeavesettingComponent } from '../../leavesetting/leavesetting.component';
import { PolicysettingComponent } from '../../policysetting/policysetting.component';
import { AddpolicyComponent } from '../../addpolicy/addpolicy.component';
import { EditpolicyComponent } from '../../editpolicy/editpolicy.component';
import { EditcompanyComponent } from '../../editcompany/editcompany.component';
import { WorkingdayslistComponent } from '../../WorkingDay/workingdayslist/workingdayslist.component';
import { DepartmentComponent } from '../../department/department.component';
import { AddworkingdaysComponent } from '../../WorkingDay/addworkingdays/addworkingdays.component';
import { LoginComponent } from 'app/login/login.component';
import { UserloginComponent } from 'app/userlogin/userlogin.component';
import { EditworkingdayComponent } from 'app/WorkingDay/editworkingday/editworkingday.component';

export const AdminLayoutRoutes: Routes = [
    
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile', component: UserProfileComponent },
    { path: 'holiday', component: HolidayComponent },
    { path: 'holiday-list', component: HolidayListComponent },
    { path: '', component: CompanylistComponent },
    { path: 'companylist', component: CompanylistComponent },
    { path: 'addcompany', component: AddcompanyComponent },
    { path: 'employee-type', component: EmployeeTypeComponent},
    { path: 'leave',   component: LeaveComponent },
    { path: 'user', component: UserComponent },
    { path: 'addEmployee', component: AddEmployeeComponent },
    { path: 'editEmployee/:Id', component: EditEmployeeComponent },
    { path: 'leavereq',   component: LeavereqComponent },
    { path: 'leavesetting',   component: LeavesettingComponent },
    { path: 'policysetting', component: PolicysettingComponent },
    { path: 'addpolicy', component: AddpolicyComponent },
    { path: 'editpolicy/:leavePolicyID', component: EditpolicyComponent },
    { path: 'company/edit/:companyID', component: EditcompanyComponent },
    { path: 'department', component: DepartmentComponent },
    { path: 'workingdayslist', component: WorkingdayslistComponent },
    { path: 'addworkingdays', component: AddworkingdaysComponent },
    { path: 'workingday/edit/:id', component: EditworkingdayComponent },
    { path: 'login', component: LoginComponent },
    { path: 'userlogin', component: UserloginComponent },
   
    
  
];
