import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./screens/home/home.component";
import { AboutUsComponent } from "./screens/about-us/about-us.component";
import { UserLoginComponent } from "./screens/user-login/user-login.component";
import { SearchResultComponent } from "./screens/search-result/search-result.component";
import { GraveDetailsComponent } from './screens/grave-details/grave-details.component';
import { GraveRegistrarsComponent } from './screens/grave-registrars/grave-registrars.component';

const routes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "home", component: HomeComponent },
  { path: "about", component: AboutUsComponent },
  { path: "login", component: UserLoginComponent },
  { path: "searchResults", component: SearchResultComponent },
  { path: "graveDetails", component: GraveDetailsComponent },
  { path: "graveRegistrars", component: GraveRegistrarsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
