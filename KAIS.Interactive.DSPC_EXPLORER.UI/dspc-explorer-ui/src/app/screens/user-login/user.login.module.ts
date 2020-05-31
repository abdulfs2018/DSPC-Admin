import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UserLoginComponent } from './user-login.component';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';


const ROUTES: Routes = [
    { path: "login", component: UserLoginComponent },
];
@NgModule({
    declarations: [
        UserLoginComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forRoot(ROUTES),
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    providers: [
    ],
    bootstrap: [],
    exports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
    ]
})
export class UserLoginModule { }
