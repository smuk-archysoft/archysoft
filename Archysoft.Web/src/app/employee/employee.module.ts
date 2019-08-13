import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { EducationComponent } from './components/education/education.component';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';
import { LanguagesComponent } from './components/languages/languages.component';
import { ProfileDetailsComponent } from './components/profile-details/profile-details.component';
import { SkillsComponent } from './components/skills/skills.component';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '../shared/shared.module';
import { CreateEmployeeComponent } from './components/create-employee/create-employee.component';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee.component';
import { ExperienceComponent } from './components/experience/experience.component';

@NgModule({
  declarations: [
    EmployeeComponent, 
    EducationComponent, 
    EmployeeDetailsComponent, 
    LanguagesComponent, 
    ProfileDetailsComponent, 
    SkillsComponent, CreateEmployeeComponent, EditEmployeeComponent, ExperienceComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    SharedModule,
    TranslateModule
  ]
})
export class EmployeeModule { }
