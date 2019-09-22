import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { MovieService } from "../movie.service";
import IMovie = namespace.IMovie;

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  public id: number;
  public movie: IMovie;
  constructor(private route: ActivatedRoute, private movieService: MovieService,) { }

  ngOnInit() {
    this.id = +this.route.snapshot.paramMap.get('id');
    this.getMovie(this.id);
  }

  getMovie(id: number) {
    this.movieService.getMovie(id).subscribe((movie: IMovie) => {
      this.movie = movie;
    });
  }

}
