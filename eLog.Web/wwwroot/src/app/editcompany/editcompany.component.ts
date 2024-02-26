import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../Models/company/company.module';
import { CompanyService } from '../Services/company.service';

@Component({
  selector: 'app-editcompany',
  templateUrl: './editcompany.component.html',
  styleUrls: ['./editcompany.component.scss']
})
export class EditcompanyComponent implements OnInit {
    imageFilePath: '';
    file: File = null;
    companydetails: Company = {
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

    constructor(private route: ActivatedRoute, private companyService: CompanyService, private router: Router) { }

    ngOnInit(): void {
        this.route.paramMap.subscribe({
            next: (params) => {
               var companyID = params.get('companyID');

                if (companyID) {
                    //call api
                    this.companyService.GetCompany(Number(companyID))
                        .subscribe({
                            next: (response) => {
                                this.companydetails = response;
                            }
                        })
                }
            }
        })
    }
    UpdateCompany() {
        if (confirm('Updated Successfully')) {
            this.companyService.UpdateCompany(this.companydetails.companyID, this.companydetails)
                .subscribe({
                    next: (response) => {
                        this.router.navigate(['/companylist']);
                    }
                })
        }
    }
    DeleteCompany(CompanyID: number) {
        if (confirm('Deleted Successfully')) {
            this.companyService.DeleteCompany(CompanyID)
                .subscribe({
                    next: (response) => {
                        this.router.navigate(['/companylist']);
                    }
                })
        }
    }
    handleFileInput(file: FileList) {
        this.file = file.item(0);
        var reader = new FileReader();
        reader.onload = (event: any) => {
            this.imageFilePath = event.target.result;
        }
        reader.readAsDataURL(this.file);
    }

    onUpload() {
        alert("upload successfully");
        this.companyService.upload(this.file, this.companydetails.companyID, this.companydetails.companyName).subscribe({
            next: (response) => {
                console.log(response);
             
                var a = response;
                this.companydetails.imageFilePath = response;
                console.log(response);
                
            }
            
        })
        
    }

}
