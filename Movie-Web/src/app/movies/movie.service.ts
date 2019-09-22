import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  getMovies() {
    return this.http.get('https://localhost:5001/api/movies');
  }

  getMovie(id: number) {
    return this.http.get(`https://localhost:5001/api/movies/${id}`);
  }

  getMoviesByCategory(category: string) {
    return this.http.get(`https://localhost:5001/api/movies/category?category=${category}`);
  }
}
