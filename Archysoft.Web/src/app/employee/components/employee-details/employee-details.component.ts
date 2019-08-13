import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { EmployeeDetailsModel } from '../../models/employee-details.model';
import { ApiResponse } from 'src/app/shared/models/api-response.model';
import { ActivatedRoute } from '@angular/router';
import { saveAs } from 'file-saver'
import { EmployeePdfModel } from '../../models/employee-pdf.model';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.scss']
})
export class EmployeeDetailsComponent implements OnInit {

  employee: EmployeeDetailsModel;

  constructor(private employeeService: EmployeeService, private route: ActivatedRoute) {
    this.employee = new EmployeeDetailsModel();
    this.route.queryParams.subscribe(params => { this.employee.id = params['id'] });

    this.employeeService.getEmployee(this.employee.id).subscribe((response: ApiResponse<EmployeeDetailsModel>) => {
      
      if (response.status === 1) {
        this.employee = response.model;
      }
    });
  }

  ngOnInit() {

  }

  downloadPdf(){
    this.employeeService.getEmployeePdf(this.employee.id)
    .subscribe((response: ApiResponse<EmployeePdfModel>) => {      
      if (response.status === 1 && response.model !== undefined) {
        var pdfModel = 'data:application/pdf;base64,' + response.model.data;
        saveAs(pdfModel, "hello world.pdf");
      }
    });
  }
}
