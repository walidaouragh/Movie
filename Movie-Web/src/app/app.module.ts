import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { MovieService } from './movies/movie.service';
import { HomeComponent } from './movies/home/home.component';
import { DetailsComponent } from './movies/details/details.component';
import { CategoryComponent } from './movies/category/category.component';
import { AddMovieComponent } from './movies/add-movie/add-movie.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
	declarations: [AppComponent, HomeComponent, DetailsComponent, CategoryComponent, AddMovieComponent],
	imports: [BrowserModule, AppRoutingModule, HttpClientModule, NgbModule, ReactiveFormsModule],
	providers: [MovieService],
	bootstrap: [AppComponent]
})
export class AppModule {}
