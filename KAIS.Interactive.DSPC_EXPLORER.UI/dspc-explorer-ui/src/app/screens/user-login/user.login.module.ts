import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserLoginComponent } from './user-login.component';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        UserLoginComponent,
    ],
    imports: [
        CommonModule,
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
