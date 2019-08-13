import { Component, OnInit, Input } from '@angular/core';
import { EmployeeDetailsModel } from '../../models/employee-details.model';

@Component({
  selector: 'app-profile-details',
  templateUrl: './profile-details.component.html',
  styleUrls: ['./profile-details.component.scss']
})
export class ProfileDetailsComponent implements OnInit {

  @Input() employee: EmployeeDetailsModel;
  
  constructor() { }
  
  ngOnInit() {
  }

}
