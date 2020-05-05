import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './core/screens/home/home.component';
import { AboutUsComponent } from './core/screens/about-us/about-us.component';
import { UserLoginComponent } from './core/screens/user-login/user-login.component';
import { FormsModule } from '@angular/forms';
import { SearchResultComponent } from './core/screens/search-result/search-result.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutUsComponent,
    UserLoginComponent,
    SearchResultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
