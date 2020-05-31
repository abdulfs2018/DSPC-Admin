import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, ROUTES } from '@angular/router';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';
import {
    HomeComponent,
    SearchCardComponent,
    SearchResultComponent
} from './';
import { NgbAlertModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { UserLoginComponent } from '../user-login/user-login.component';
import { AboutUsComponent } from '../about-us/about-us.component';
import { GraveDetailsComponent } from '../grave-details/grave-details.component';
import { GraveRegistrarsComponent } from '../grave-registrars/grave-registrars.component';

const routes: Routes = [
    { path: "", redirectTo: "home", pathMatch: "full" },
    { path: "home", component: HomeComponent },
    { path: "about", component: AboutUsComponent },
    { path: "login", component: UserLoginComponent },
    { path: "graveDetails", component: GraveDetailsComponent },
    { path: "graveRegistrars", component: GraveRegistrarsComponent }
];


@NgModule({
    declarations: [
        HomeComponent,
        SearchCardComponent,
        SearchResultComponent,
        HeaderComponent,
        FooterComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forRoot(routes),
        NgbPaginationModule,
        NgbAlertModule,
        HttpClientModule,
        FormsModule
    ],
    providers: [],
    bootstrap: [],
    exports: [
        HomeComponent
    ]
})
export class HomeModule {

}