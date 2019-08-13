import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesComponent } from './employees.component';
import { EmployeesCardsComponent } from './components/employees-cards/employees-cards.component';
import { EmployeesGridComponent } from './components/employees-grid/employees-grid.component';

const routes: Routes = [
 
  {
    path: '',
    component: EmployeesComponent,
    children:[
      {path: 'employees-grid', component:EmployeesGridComponent},
      {path: 'employees-cards', component:EmployeesCardsComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeesRoutingModule { }
