import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../Services/company.service';
import { Company } from '../Models/company/company.module';

@Component({
  selector: 'app-companylist',
  templateUrl: './companylist.component.html',
  styleUrls: ['./companylist.component.scss']
})
export class CompanylistComponent implements OnInit {
  p: number = 1;
  companyName='';

  constructor(private companyService: CompanyService) { }
    company: Company[] = [];

    ngOnInit(): void {
        this.companyService.GetAllCompany()
            .subscribe({
                next: (company) => {
                    this.company = company;
                },
                error: (response) => {
                console.log(response);
            } 
            })
    }
    Search() {
      if (this.companyName== "") {
          this.ngOnInit();
      } else {
          this.company = this.company.filter(res => {
              return res.companyName.toLocaleLowerCase().match(this.companyName.toLocaleLowerCase());
          })
      }
  }

}
