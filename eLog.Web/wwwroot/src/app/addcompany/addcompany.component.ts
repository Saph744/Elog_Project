import { HttpClient } from '@angular/common/http';
import { Component, OnInit  } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../Models/company/company.module';
import { CompanyService } from '../Services/company.service';

@Component({
  selector: 'app-addcompany',
  templateUrl: './addcompany.component.html',
  styleUrls: ['./addcompany.component.scss']
})
export class AddcompanyComponent implements OnInit {
    
    constructor(private companyService: CompanyService, private router: Router, private http: HttpClient) { } 
    companyViewModel: Company = {
        companyID: 0,
        companyName: '',
        companyAbbreviation: '',
        phoneNumber: '',
        extension: '',
        faxNumber: '',
        emailAddress: '',
        website: '',
        country: '',
        countryCode: '',
        state: '',
        city: '',
        address: '',
        imageName: '',
        imageFilePath: '',
        createdBy: 0,
        createdTS: '',
        modifiedBy: 0,
       
    }


    ngOnInit(): void {
    }


    InsertCompany() { 
        if (confirm('Added Successfully')) {
            this.companyService.InsertCompany(this.companyViewModel)
                .subscribe({
                    next: (Company) => {
                        this.router.navigate(['/companylist']);
                    }
                })
        }
    }


}
