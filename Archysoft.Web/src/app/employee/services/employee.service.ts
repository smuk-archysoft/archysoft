import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/shared/models/api-response.model';
import { environment } from 'src/environments/environment';
import { EmployeeDetailsModel } from '../models/employee-details.model';
import { EmployeePdfModel } from '../models/employee-pdf.model';


@Injectable({
    providedIn: 'root'
})
export class EmployeeService extends BaseService {
    constructor(httpClient: HttpClient) {
        super(httpClient);
    }
 
    getEmployee(id: string): Observable<ApiResponse<EmployeeDetailsModel>> {
        var params = new HttpParams().set('id', id)
        return this.getT<EmployeeDetailsModel>(`${environment.apiUrl}/employees/get`, params);
    }

    getEmployeePdf(id: string): Observable<ApiResponse<EmployeePdfModel>> {
        var params = new HttpParams().set('id', id);
        return this.getT<EmployeePdfModel>(`${environment.apiUrl}/employee/get-pdf-document`, params);
    }
}