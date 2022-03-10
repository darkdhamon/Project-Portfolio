import {Component, Input, OnInit} from '@angular/core';
import { Project } from '../view-models/Project';
import { ProjectCard } from '../view-models/ProjectCard';

@Component({
  selector: 'app-project-card',
  templateUrl: './project-card.component.html',
  styleUrls: ['./project-card.component.scss'],
})
export class ProjectCardComponent implements OnInit {

  @Input() project: ProjectCard
  constructor() {
    this.project = <ProjectCard>{};
  }

  ngOnInit() {
  }

}
