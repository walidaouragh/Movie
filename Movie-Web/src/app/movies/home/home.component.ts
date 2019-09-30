import { Component, OnInit, ViewChild } from '@angular/core';
import { MovieService } from '../movie.service';
import IMovie = namespace.IMovie;
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
	selector: 'app-home',
	templateUrl: './home.component.html',
	styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
	public movies: IMovie[];
	public movie: IMovie;
	public categories = ['Drama', 'Comedy', 'Romance'];
	public form: FormGroup;
	@ViewChild('modal', { static: false }) modal: any;

	constructor(private movieService: MovieService, private router: Router, private modalService: NgbModal) {}

	ngOnInit(): void {
		this.CreateForm();
		this.getMovies();
	}

	CreateForm() {
		this.form = new FormGroup({
			name: new FormControl(),
			category: new FormControl(),
			description: new FormControl(),
			price: new FormControl()
		});
	}

	getMovies() {
		this.movieService.getMovies().subscribe((movies: IMovie[]) => {
			this.movies = movies;
		});
	}

	getMovieDetail(id: number) {
		this.router.navigate([`details/${id}`]);
	}

	getMoviesByCategory(category: string) {
		this.router.navigate([`category/${category}`]);
	}

	createMovie() {
		this.modalService.open(this.modal, { size: 'lg' });
	}

	onCancel() {}

	onSave() {
		this.movie = Object.assign({}, this.form.value);
		this.movieService.creatMovie(this.movie).subscribe((m: IMovie) => (this.movie = m));
		this.movies.push(this.movie);
		this.modalService.dismissAll();
		this.form.reset();
	}

	deleteMovie(id: number) {
		console.log(id);
		this.movieService.deleteMovie(id).subscribe(m => console.log(m));
	}
}
