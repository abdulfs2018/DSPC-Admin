import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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

const ROUTES: Routes = [
    { path: "login", component: UserLoginComponent },
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
        RouterModule.forRoot(ROUTES),
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