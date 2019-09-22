import { Component, OnInit } from '@angular/core';
import { MovieService } from "../movie.service";
import IMovie = namespace.IMovie;
import { Router } from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  public movies: IMovie[];
  public movie: IMovie;
  public categories = ['Drama', 'Comedy', 'Romance'];

  constructor(private movieService: MovieService, private router: Router) {}

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies() {
    this.movieService.getMovies().subscribe((movies: IMovie[]) => {
      this.movies = movies;
    });
  }

  getMovieDetail(id: number) {
      this.router.navigate([`details/${id}`])
  };

  getMoviesByCategory(category: string) {
    this.router.navigate([`category/${category}`])
  };
}
