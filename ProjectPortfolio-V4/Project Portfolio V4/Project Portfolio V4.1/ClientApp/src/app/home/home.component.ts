import {Component, OnInit, ViewChild} from '@angular/core';
import {ProjectCard} from "../view-models/ProjectCard";
import {HttpClient} from "@angular/common/http";
import {ApiResponse} from "../view-models/ApiResponse";
import {NgbCarousel, NgbSlideEvent, NgbSlideEventSource} from "@ng-bootstrap/ng-bootstrap";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private http: HttpClient) { }

  projectSlides: ProjectCard[] = [];
  paused = false;
  unpauseOnArrow = false;
  pauseOnIndicator = false;

  @ViewChild('FeaturedCarousel', {static:false}) featuredCarousel: NgbCarousel | undefined;

  ngOnInit(): void {
    this.http.get<ApiResponse<ProjectCard[]>>("api/Project/Featured")
      .subscribe(response =>
      {
        this.projectSlides = response.data;
      });
  }

  onSlide(slideEvent: NgbSlideEvent){
    if(
      (
        this.unpauseOnArrow &&
        slideEvent.paused &&
        (
          slideEvent.source === NgbSlideEventSource.ARROW_LEFT ||
          slideEvent.source === NgbSlideEventSource.ARROW_RIGHT
        )
      ) ||
      (
        this.pauseOnIndicator &&
        !slideEvent.paused &&
        slideEvent.source === NgbSlideEventSource.INDICATOR
      )
    ){
      this.togglePause();
    }
  }

  togglePause(){
    if(this.featuredCarousel){
      if(this.paused){
        this.featuredCarousel.cycle();
      }else{
        this.featuredCarousel.pause();
      }
      this.paused = !this.paused;
    }
  }
}
