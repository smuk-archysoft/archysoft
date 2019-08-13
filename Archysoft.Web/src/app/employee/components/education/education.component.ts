import { Component, OnInit, Input } from '@angular/core';
import { EducationModel } from '../../models/education.model';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss']
})
export class EducationComponent implements OnInit {

  @Input() educations: EducationModel[];
  
  constructor() { }

  ngOnInit() {
  }

}
