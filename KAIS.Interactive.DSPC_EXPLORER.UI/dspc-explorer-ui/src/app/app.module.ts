import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { AboutUsComponent } from "./screens/about-us/about-us.component";
import { FormsModule } from "@angular/forms";
import { SearchResultComponent } from "./screens/search-result/search-result.component";
import { SearchCardComponent } from './screens/search-card/search-card.component';
import {NgbPaginationModule, NgbAlertModule} from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from './screens/header/header.component';
import { FooterComponent } from './screens/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { GraveDetailsComponent } from './screens/grave-details/grave-details.component';
import { GraveDetailsRegistrarsComponent } from './screens/grave-details-registrars/grave-details-registrars.component';
import { GraveRegistrarsComponent } from './screens/grave-registrars/grave-registrars.component';
import { HomeModule } from './screens/home/home.module';
import { UserLoginModule } from './screens/user-login/user.login.module';

@NgModule({
  declarations: [
    AppComponent,
    AboutUsComponent,
    UserLoginComponent,
    SearchResultComponent,
    SearchCardComponent,
    HeaderComponent,
    FooterComponent,
    GraveDetailsComponent,
    GraveDetailsRegistrarsComponent,
    GraveRegistrarsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HomeModule,
    UserLoginModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
