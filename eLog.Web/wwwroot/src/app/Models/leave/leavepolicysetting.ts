export interface leavepolicysetting
{
    leavePolicySettingID: number;
    companyID: number;
    leaveTypeID: number;
    effectiveDate: Date;
    initialBalance: number;
    earnDays: number;
    earnPeriodId: number;
    resetAtID: string;
    resetDay: number;
    maxAvailableDays: number;
    enableSandwich: boolean;
    disabaleNegativeBalance: boolean;
    sandwichCount: number;
    isActive: boolean;
    createdBy: number;
    createdTS: Date;
    leavePolicyID: number;
    description: string;
}
