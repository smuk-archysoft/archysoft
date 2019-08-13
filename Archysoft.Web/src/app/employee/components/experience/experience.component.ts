import { Component, OnInit, Input } from '@angular/core';
import { ExperienceModel } from '../../models/experience.model';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.scss']
})
export class ExperienceComponent implements OnInit {

  @Input() experience: ExperienceModel[];

  constructor() { }

  ngOnInit() {
  }
  
}
