import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { FormsModule } from "@angular/forms";
import { GraveDetailsComponent } from './screens/grave-details/grave-details.component';
import { GraveDetailsRegistrarsComponent } from './screens/grave-details-registrars/grave-details-registrars.component';
import { GraveRegistrarsComponent } from './screens/grave-registrars/grave-registrars.component';
import { StorageServiceModule } from 'ngx-webstorage-service';
import { DSPCExplorerLocalStorageProvider } from './core/services/dspc-explorer-provider/dspc-explorer-storage-provider';
import { HomeModule } from './screens/home/home.module';
import { UserLoginModule } from './screens/user-login/user.login.module';

@NgModule({
  declarations: [
    AppComponent,
    GraveDetailsComponent,
    GraveDetailsRegistrarsComponent,
    GraveRegistrarsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    FormsModule,
    StorageServiceModule,
    HomeModule,
    UserLoginModule
  ],
  providers: [DSPCExplorerLocalStorageProvider],
  bootstrap: [AppComponent],
})
export class AppModule { }
