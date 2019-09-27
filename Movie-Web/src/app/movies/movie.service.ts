import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import IMovie = namespace.IMovie;

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  getMovies() {
    return this.http.get('https://localhost:5001/api/movie');
  }

  getMovie(id: number) {
    return this.http.get(`https://localhost:5001/api/movie/${id}`);
  }

  getMoviesByCategory(category: string) {
    return this.http.get(`https://localhost:5001/api/movie/category?category=${category}`);
  }

  creatMovie(movie: IMovie) {
    return this.http.post('https://localhost:5001/api/movie', movie);
  }

  deleteMovie(movieId: number) {
    return this.http.delete(`https://localhost:5001/api/movie/${movieId}`)
  }
}
