import { MatPaginator, PageEvent, Sort, MatDialog } from '@angular/material';
import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { EmployeesDataSource } from '../../services/employees.datasource';
import { EmployeesService } from '../../services/employees.service';
import { Router } from '@angular/router';
import { EmployeeGridModel } from '../../models/employee-grid.model';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'employees-grid',
  templateUrl: './employees-grid.component.html',
  styleUrls: ['./employees-grid.component.scss']
})
export class EmployeesGridComponent implements OnInit {
  displayedColumns: string[] = ['id', 'userName', 'firstName', 'lastName', 'email'];
  dataSource: EmployeesDataSource;

  length = 100;
  pageSize = 5;
  pageIndex = 0;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  filterValue: string = '';
  direction: string = '';
  sortValue: string = '';
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private employeesService: EmployeesService) { }

  ngOnInit() {
    this.dataSource = new EmployeesDataSource(this.employeesService);
    this.dataSource.loadEmployees({ search: this.filterValue, orderBy: this.sortValue, direction: this.direction, pageIndex: this.pageIndex, pageSize: this.pageSize });
    this.dataSource.getTotal().subscribe((x) => {
      this.length = x;
    });
    this.dataSource.getLoading().subscribe((x) => {
      this.loading = x;
    });
  }

  setEmployees(pageEvent: PageEvent) {
    this.dataSource.loadEmployees({ search: this.filterValue, orderBy: this.sortValue, direction: this.direction, pageIndex: pageEvent.pageIndex, pageSize: pageEvent.pageSize });
    this.pageSize = pageEvent.pageSize;
    this.pageIndex = pageEvent.pageIndex;
    this.loading = false;
  }

  sortEmployees(sort: Sort) {
    this.dataSource.loadEmployees({ search: this.filterValue, orderBy: sort.active, direction: sort.direction, pageIndex: this.pageIndex, pageSize: this.pageSize });

    this.sortValue = sort.active;
    this.direction = sort.direction;
    this.loading = false;
  }

  applyFilterEmployees(filterValue: string) {
    this.dataSource.loadEmployees({ search: filterValue, orderBy: this.sortValue, direction: this.direction, pageIndex: this.pageIndex, pageSize: this.pageSize });

    this.filterValue = filterValue;
    this.loading = false;
  }

  @Output() switchToView = new EventEmitter();
  switchToCardsView() {
    this.switchToView.emit();
  }

  @Output() childEvent = new EventEmitter<string>();
  goToEmployeeDetails(employee: EmployeeGridModel) {
    this.childEvent.emit(employee.id);
  }
}
