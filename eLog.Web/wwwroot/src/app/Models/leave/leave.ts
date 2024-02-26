export interface leave {
    //LeaveApproval Model
    leaveApprovalID: number;
    companyID: number;
    startDate: Date;
    endDate: Date;
    daysOff: number;
    hourOff: number;
    leaveReason: string;
    approvalStatus: string;
    noticePeriod: number;
    employeeID: number;
    leaveTypeID: number;
    leavePolicyID: number;
    createdBy: number;
    createdTS: Date;

    description: string;
    firstname: string;
    middleName: string;
    lastname: string;
    contactID: number;


}
