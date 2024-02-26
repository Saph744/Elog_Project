import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminLayoutRoutes } from './admin-layout.routing';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { HolidayComponent } from '../../holiday/holiday.component';
import { HolidayListComponent } from '../../holiday-list/holiday-list.component';
import { LeaveComponent } from '../../leave/leave.component';
import { LeavereqComponent } from '../../leavereq/leavereq.component';
import { MatButtonModule } from '@angular/material/button';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { NgxPaginationModule } from 'ngx-pagination';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { UserComponent } from '../../user/user.component';
import { AddEmployeeComponent } from '../../user/add-employee/add-employee.component';
import { MatTabsModule } from '@angular/material/tabs';
import { EditEmployeeComponent } from '../../user/edit-employee/edit-employee.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ShowDeleteHolidayComponent } from '../../holiday/show-delete-holiday/show-delete-holiday.component';
import { AddEditHolidayComponent } from '../../holiday/add-edit-holiday/add-edit-holiday.component';
import { EmployeeTypeComponent } from '../../employee-type/employee-type.component';
import { CompanylistComponent } from '../../companylist/companylist.component';
import { AddcompanyComponent } from '../../addcompany/addcompany.component';
import { LeavesettingComponent } from '../../leavesetting/leavesetting.component';
import { PolicysettingComponent } from '../../policysetting/policysetting.component';
import { AddpolicyComponent } from '../../addpolicy/addpolicy.component';
import { EditpolicyComponent } from '../../editpolicy/editpolicy.component';
import { EditcompanyComponent } from '../../editcompany/editcompany.component';
import { WorkingdayslistComponent } from '../../WorkingDay/workingdayslist/workingdayslist.component';
import { AddworkingdaysComponent } from '../../WorkingDay/addworkingdays/addworkingdays.component';
import { LoginComponent } from 'app/login/login.component';
import { EditworkingdayComponent } from 'app/WorkingDay/editworkingday/editworkingday.component';
import { DepartmentComponent } from '../../department/department.component';
import { MatInputModule } from '@angular/material/input'; 

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTooltipModule,
    MatPaginatorModule,
        MatPaginatorModule,
        Ng2OrderModule,
        NgxPaginationModule,
        MatDatepickerModule,
        MatPaginatorModule,
        MatSlideToggleModule,
        NgxPaginationModule,
        Ng2OrderModule,
        MatTabsModule,
        MatInputModule ,
  ],
  declarations: [
    DashboardComponent,
      UserProfileComponent,
      CompanylistComponent,
      AddcompanyComponent,
        UserComponent,
      AddEmployeeComponent,
      EditEmployeeComponent,
      LeaveComponent,
      LeavereqComponent,
      LeavesettingComponent,
      PolicysettingComponent,
      AddpolicyComponent,
      EditpolicyComponent,
      LoginComponent,
      HolidayComponent,
      HolidayListComponent,
      ShowDeleteHolidayComponent,
      AddEditHolidayComponent,
      EmployeeTypeComponent,
      EditcompanyComponent,
      WorkingdayslistComponent,
      DepartmentComponent,
      AddworkingdaysComponent,
      EditworkingdayComponent,
  ]
})

export class AdminLayoutModule { }
