import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { EmployeesService } from '../../services/employees.service';
import { PageEvent, MatSelectChange } from '@angular/material';
import { EmployeeGridModel } from '../../models/employee-grid.model';
import { Router } from '@angular/router';

interface SortValues {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'employees-cards',
  templateUrl: './employees-cards.component.html',
  styleUrls: ['./employees-cards.component.scss']
})
export class EmployeesCardsComponent implements OnInit {

  employees: EmployeeGridModel[];

  @Output() switchToView = new EventEmitter(); 

  displayedColumns: string[] = ['employee card'];
  length = 100;
  pageSize = 5;
  pageIndex = 0;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  filterValue: string = '';
  direction: string = 'asc';
  sortValue: string = 'userName';
  loading: boolean = false;

  sortValues: SortValues[] = [
    { value: 'id', viewValue: 'Id' },
    { value: 'email', viewValue: 'Email' },
    { value: 'userName', viewValue: 'User name' },
    { value: 'firstName', viewValue: 'First name' },
    { value: 'lastName', viewValue: 'Last name' }
  ];
 
  constructor(private employeesService: EmployeesService) { }

  ngOnInit() {
    this.employeesService.getEmployees({ search: this.filterValue, orderBy: this.sortValue, direction: this.direction, pageIndex: this.pageIndex, pageSize: this.pageSize })
      .subscribe((y) => { this.employees = y.model.data });
  }

  setEmployees(pageEvent: PageEvent) {
    this.employeesService.getEmployees({ search: this.filterValue, orderBy: this.sortValue, direction: this.direction, pageIndex: pageEvent.pageIndex, pageSize: pageEvent.pageSize })
      .subscribe((y) => { this.employees = y.model.data });

    this.pageSize = pageEvent.pageSize;
    this.pageIndex = pageEvent.pageIndex;
    this.loading = false;
  }

  sortEmployees(sort: MatSelectChange) {
    this.employeesService.getEmployees({ search: this.filterValue, orderBy: sort.value, direction: this.direction, pageIndex: this.pageIndex, pageSize: this.pageSize })
      .subscribe((y) => { this.employees = y.model.data });

    this.sortValue = sort.value;
    this.loading = false;
  }

  applyFilterEmployees(filterValue: string) {
    this.employeesService.getEmployees({ search: filterValue, orderBy: this.sortValue, direction: this.direction, pageIndex: this.pageIndex, pageSize: this.pageSize })
      .subscribe((y) => { this.employees = y.model.data });

    this.filterValue = filterValue;
    this.loading = false;
  }

  switchToGridView() {
    this.switchToView.emit();
  }

  @Output() childEvent = new EventEmitter<string>();
  goToEmployeeDetails(employee: EmployeeGridModel){
    this.childEvent.emit(employee.id);
  }
}
