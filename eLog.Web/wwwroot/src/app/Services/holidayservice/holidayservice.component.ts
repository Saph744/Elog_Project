import { Component, OnInit, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { holiday } from '../../Models/holiday/holiday';
import { environment } from '../../../environments/environment';
import { userleavedetail } from '../../Models/leave/userleavedetail';
import { leavetype } from '../../Models/leave/leavetype';
import { employee } from '../../Models/employee';
import { leavepolicy } from '../../Models/leave/leavepolicy';
import { leave } from '../../Models/leave/leave';
import { leavepolicysetting } from '../../Models/leave/leavepolicysetting';

@Injectable({
    providedIn: 'root'
})
export class HolidayserviceComponent {
    baseApiUrl: string = environment.baseApiUrl;
    constructor(private http: HttpClient) { }

    GetAllHoliday(): Observable<holiday[]> {
        return this.http.get<holiday[]>(this.baseApiUrl + '/api/HolidayDetail/GetAllHoliday')
    }
    GetAllUserLeave(): Observable<userleavedetail[]> {
        return this.http.get<userleavedetail[]>(this.baseApiUrl + '/api/UserLeaveDetail/GetAllUserLeave')
    }
    GetAllLeaveType(): Observable<leavetype[]> {
        return this.http.get<leavetype[]>(this.baseApiUrl + '/api/LeaveType/GetAllLeaveType')
    }
    GetAllData(): Observable<employee[]> {
        return this.http.get<employee[]>(this.baseApiUrl + '/api/Contact/GetAllData')
    }
    GetAllLeavePolicy(): Observable<leavepolicy[]> {
        return this.http.get<leavepolicy[]>(this.baseApiUrl + '/api/LeavePolicy/GetAllLeavePolicy')
    }
    GetAllLeaveApp(): Observable<leave[]> {
        return this.http.get<leave[]>(this.baseApiUrl + '/api/LeaveApproval/GetAllLeaveApp')
    }
    deleteLeave(leaveTypeID): Observable<leavetype[]> {
        return this.http.delete<leavetype[]>(this.baseApiUrl + '/api/LeaveType/DeleteLeaveType?LeaveTypeID=' + leaveTypeID)
    }
    editLeaveType(LeaveType): Observable<leavetype[]> {
        return this.http.put<leavetype[]>(this.baseApiUrl + '/api/LeaveType/UpdateLeaveType', LeaveType)
    }
    deletePolicy(leavePolicyID): Observable<leavepolicy[]> {
        return this.http.delete<leavepolicy[]>(this.baseApiUrl + '/api/LeavePolicy/DeleteLeavePolicy?LeavePolicyID=' + leavePolicyID)
    }
    insertleaveType(LeaveType): Observable<leavetype[]> {
        return this.http.post<leavetype[]>(this.baseApiUrl + '/api/LeaveType/InsertLeaveType', LeaveType)
    }
    insertleavePolicy(LeavePolicy): Observable<leavepolicy[]> {
        return this.http.post<leavepolicy[]>(this.baseApiUrl + '/api/LeavePolicy/InsertLeavePolicy', LeavePolicy)
    }
    editLeavePolicy(LeavePolicyID: number, leavePolicyViewNodel: leavepolicy): Observable<leavepolicy[]> {
        return this.http.put<leavepolicy[]>(this.baseApiUrl + '/api/LeavePolicy/UpdateLeavePolicy/?LeavePolicyID=' + LeavePolicyID, leavePolicyViewNodel)
    }
    getLeavePolicyByID(leavePolicyID): Observable<leavepolicy[]> {
        return this.http.get<leavepolicy[]>(this.baseApiUrl + '/api/LeavePolicy/GetLeavePolicyByID?LeavePolicyID='+ leavePolicyID)
    }
    getAllLeavePolicySetting(): Observable<leavepolicysetting[]> {
        return this.http.get<leavepolicysetting[]>(this.baseApiUrl + '/api/LeavePolicySetting/GetAllLeaveSetting')
    }
    LeaveReqInsert(leave): Observable<leave[]> {
        return this.http.post<leave[]>(this.baseApiUrl + '/api/LeaveApproval/InsertLeaveRequest', leave)
    }
    getPolicyDataByID(leavePolicyID): Observable<leavepolicysetting[]> {
        return this.http.get<leavepolicysetting[]>(this.baseApiUrl + '/api/LeavePolicySetting/GetLeavePolicyByID?LeavePolicyID=' + leavePolicyID)
    }
}
