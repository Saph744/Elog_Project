import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Company } from '../Models/company/company.module';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

    baseApiUrl: string = environment.baseApiUrl;
    constructor(private http: HttpClient) { }
    GetAllCompany(): Observable<Company[]> {
        return this.http.get<Company[]>(this.baseApiUrl + '/api/Company/GetAllCompany')
    }

    InsertCompany(companyViewModel: Company): Observable<Company> {
        return this.http.post<Company>(this.baseApiUrl + '/api/Company/InsertCompany', companyViewModel);
    }

    GetCompany(CompanyID: number): Observable<Company> {
        return this.http.get<Company>(this.baseApiUrl + '/api/Company/GetCompany?companyID=' + CompanyID);
    }

    UpdateCompany(CompanyID: number, companyViewModel: Company): Observable<Company> {
        return this.http.put<Company>(this.baseApiUrl + '/api/Company/UpdateCompany/?companyID=' + CompanyID, companyViewModel); 
    }

    DeleteCompany(CompanyID: number): Observable<Company> {
        return this.http.delete<Company>(this.baseApiUrl + '/api/Company/DeleteCompany/?companyID=' + CompanyID); 
    }
    // Returns an observable
    upload(file, CompanyID, companyName): Observable<any> {
       
        // Create form data
        const formData = new FormData();
        var fileName =  CompanyID;
        // Store form name as "file" with file data
        formData.append("file", file, fileName);
        debugger;
        // Make http post request over api
        // with formData as req
        return this.http.post<any>(this.baseApiUrl + '/api/Company/UploadFiles/', formData)
    }
}
