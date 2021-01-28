import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent, AboutUsComponent, SearchResultComponent } from "./";
import {
  HeaderComponent,
  FooterComponent,
  GraveDetailsComponent,
  GraveRegistrarsComponent,
} from "../";

import {
  NgbAlertModule,
  NgbPaginationModule,
} from "@ng-bootstrap/ng-bootstrap";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { UserLoginComponent } from "../user-login/user-login.component";
import { ReactiveFormsModule } from "@angular/forms";
import { CustomLoaderComponent } from './custom-loader/custom-loader.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const routes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "home", component: HomeComponent },
  { path: "about", component: AboutUsComponent },
  { path: "login", component: UserLoginComponent },
  { path: "graveDetails", component: GraveDetailsComponent },
  { path: "graveRegistrars", component: GraveRegistrarsComponent },
];

@NgModule({
  declarations: [
    HomeComponent,
    AboutUsComponent,
    SearchResultComponent,
    HeaderComponent,
    FooterComponent,
    CustomLoaderComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [],
  exports: [HomeComponent],
})
export class HomeModule {}
