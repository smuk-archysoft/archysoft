import { Component, OnInit } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {

  isCardsViewSwitched: boolean = false;
  switchButtonText: string = 'Switch to Cards View';
  constructor(private router: Router) { }

  ngOnInit() {
  }

  switchToView() {
    this.isCardsViewSwitched = !this.isCardsViewSwitched;
    if (!this.isCardsViewSwitched) {
      this.switchButtonText = 'Switch to Cards View';
    }
    else {
      this.switchButtonText = 'Switch to Grid View';
    }
  }

  goToEmployee(employeeId: string){ 
    this.router.navigate(['/employee'],
      { queryParams:{ 'id': employeeId }}
    );
  } 
}
