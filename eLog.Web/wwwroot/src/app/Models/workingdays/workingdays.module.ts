export interface workingday {
    workingDayID: number;
    hourPerDay: number;
    description: string;
    isActive: boolean;
    companyID: number;
    sun: boolean;
    mon: boolean;
    tue: boolean;
    wed: boolean;
    thu: boolean;
    fri: boolean;
    sat: boolean;
    createdBy: number;
    createdTS: Date;
}