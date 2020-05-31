import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./screens/home/home.component";
import { AboutUsComponent } from "./screens/about-us/about-us.component";
import { UserLoginComponent } from "./screens/user-login/user-login.component";
import { GraveDetailsComponent } from './screens/grave-details/grave-details.component';
import { GraveRegistrarsComponent } from './screens/grave-registrars/grave-registrars.component';



@NgModule({
  imports: [],
  exports: [RouterModule],
})
export class AppRoutingModule { }
