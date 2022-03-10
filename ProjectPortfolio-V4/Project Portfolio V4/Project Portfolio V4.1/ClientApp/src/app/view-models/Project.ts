import { ProjectCard } from '../view-models/ProjectCard';

export interface Project extends ProjectCard{
  description: string;
  endDate: Date;
  startDate: Date;
}
