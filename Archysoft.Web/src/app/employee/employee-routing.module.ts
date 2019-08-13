import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';
import { EmployeeComponent } from './employee.component';
import { CreateEmployeeComponent } from './components/create-employee/create-employee.component';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee.component';

const routes: Routes = [
  {
    path: '', 
    component: EmployeeComponent, 
    children: [
      {path: '', component: EmployeeDetailsComponent},
      {path: 'create', component: CreateEmployeeComponent},
      {path: 'edit', component: EditEmployeeComponent}
    ]
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
