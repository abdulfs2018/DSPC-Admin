import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeScreenComponent } from './home-screen/home-screen.component';
import { HomeComponent } from './core/screens/home/home.component';
import { AboutUsComponent } from './core/screens/about-us/about-us.component';
import { UserLoginComponent } from './core/screens/user-login/user-login.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeScreenComponent,
    HomeComponent,
    AboutUsComponent,
    UserLoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
