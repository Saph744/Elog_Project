import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { workingday } from '../../Models/workingdays/workingdays.module';


@Injectable({
  providedIn: 'root'
})
export class WorkingdayService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  GetAllWorkingdays(): Observable<workingday[]> {
    return this.http.get<workingday[]>(this.baseApiUrl + '/api/WorkingDay/GetAllWorkingDay')
  }

  Insertworkingday(workingDayViewModel: workingday): Observable<workingday> {
    return this.http.post<workingday>(this.baseApiUrl + '/api/WorkingDay/InsertWorkingDay', workingDayViewModel);
  }

  GetWorkingDay(WorkingDayID: number): Observable<workingday> {
    return this.http.get<workingday>(this.baseApiUrl + '/api/WorkingDay/GetWorkingDay/?WorkingDayID=' + WorkingDayID);
  }

    UpdateWorkingday(WorkingDayID: number, workingDayViewModel: workingday): Observable<workingday> {
        return this.http.put<workingday>(this.baseApiUrl + '/api/WorkingDay/UpdateWorkingDay/?workingDayID=' + WorkingDayID, workingDayViewModel);
  }

    DeleteWorkingday(WorkingDayID: number): Observable<workingday> {
        return this.http.delete<workingday>(this.baseApiUrl + '/api/WorkingDay/DeleteWorkingDay/?workingDayID=' + WorkingDayID);
  }
}
