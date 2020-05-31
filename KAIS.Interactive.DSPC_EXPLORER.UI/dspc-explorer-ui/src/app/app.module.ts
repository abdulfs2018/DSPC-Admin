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
import { HeaderComponent } from './screens/header/header.component';
import { FooterComponent } from './screens/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { GraveDetailsComponent } from './screens/grave-details/grave-details.component';
import { GraveDetailsRegistrarsComponent } from './screens/grave-details-registrars/grave-details-registrars.component';
import { GraveRegistrarsComponent } from './screens/grave-registrars/grave-registrars.component';
import { StorageServiceModule } from 'ngx-webstorage-service';
import { DSPCExplorerLocalStorageProvider } from './core/services/dspc-explorer-provider/dspc-explorer-storage-provider';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
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
    NgbPaginationModule,
    NgbAlertModule,
    HttpClientModule,
    FormsModule,
    StorageServiceModule
  ],
  providers: [DSPCExplorerLocalStorageProvider],
  bootstrap: [AppComponent],
})
export class AppModule { }
