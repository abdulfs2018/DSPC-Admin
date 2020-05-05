import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent} from './core\\screens/home/home.component';
import { AboutUsComponent} from './core\\screens/about-us/about-us.component';
import { UserLoginComponent} from './core\\screens/user-login/user-login.component';
import { SearchResultComponent } from './core/screens/search-result/search-result.component';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutUsComponent },
  { path: 'login', component: UserLoginComponent }, 
  { path: 'searchResults', component: SearchResultComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
