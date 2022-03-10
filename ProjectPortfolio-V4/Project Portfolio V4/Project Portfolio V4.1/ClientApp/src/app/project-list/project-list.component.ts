import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { ProjectCard } from "../view-models/ProjectCard";
import {PagedApiResponse} from "../view-models/PagedApiResponse";

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent implements OnInit {
  projects: ProjectCard[];
  page: number;
  totalPages: number;

  constructor(private http: HttpClient) {
    this.projects = [];
    this.page = 1;
    this.totalPages = 1;
  }
  ngOnInit(): void {
    this.getProjectsToList();
  }

  generatePageArray(): number[] {
    let result: number[] = [];
    for (let _i = 0; _i < this.totalPages; _i++) {
      result.push(_i + 1);
    }
    return result;
  }

  incrementPageNumber() {
    this.setPageNumber(this.page + 1);
  }

  decrementPageNumber() {
    this.setPageNumber(this.page - 1);
  }

  setPageNumber(pageNum: number) {
    this.page = pageNum;
    this.getProjectsToList();
  }

  getProjectsToList() {
    ///Make call to DB for porject lists
    this.http.get<PagedApiResponse<ProjectCard[]>>("api/Project/page/" + this.page)
      .subscribe(response => {
        this.projects = response.data;
        this.totalPages = response.totalPages;
    });
  }
}
