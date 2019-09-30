import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './movies/home/home.component';
import { DetailsComponent } from './movies/details/details.component';
import { CategoryComponent } from './movies/category/category.component';

const routes: Routes = [
	{ path: '', component: HomeComponent },
	{ path: 'details/:id', component: DetailsComponent },
	{ path: 'category/:category', component: CategoryComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {}
