import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeesRoutingModule } from './employees-routing.module';
import { EmployeesComponent } from './employees.component';
import { SharedModule } from '../shared/shared.module';
import { EmployeesGridComponent } from './components/employees-grid/employees-grid.component';
import { TranslateModule } from '@ngx-translate/core';
import { EmployeesCardsComponent } from './components/employees-cards/employees-cards.component';

@NgModule({
  declarations: [EmployeesComponent, EmployeesGridComponent, EmployeesCardsComponent],
  imports: [
    CommonModule,
    EmployeesRoutingModule,
    SharedModule,
    TranslateModule
  ]
})
export class EmployeesModule { }
