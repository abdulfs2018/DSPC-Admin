import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./screens/home/home.component";
import { AboutUsComponent } from "./screens/about-us/about-us.component";
import { UserLoginComponent } from "./screens/user-login/user-login.component";
import { FormsModule } from "@angular/forms";
import { SearchResultComponent } from "./screens/search-result/search-result.component";
import { SearchCardComponent } from './screens/search-card/search-card.component';
import {NgbPaginationModule, NgbAlertModule} from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutUsComponent,
    UserLoginComponent,
    SearchResultComponent,
    SearchCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbPaginationModule,
    NgbAlertModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
