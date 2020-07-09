import { Component, OnInit } from '@angular/core';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';
import { RegistrarDTO } from 'src/app/core/dtos/registrar.model';

@Component({
  selector: 'app-grave-registrars',
  templateUrl: './grave-registrars.component.html',
  styleUrls: ['./grave-registrars.component.scss']
})
export class GraveRegistrarsComponent implements OnInit {

  constructor(private dspcExplorerDataProvider: DSPCExplorerDataProvider, private localStorageService: DSPCExplorerLocalStorageProvider) { }

  registrar : RegistrarDTO;
  private isAdmin: boolean;
  readonly REGISTRAR_KEY = "local_registar";

  ngOnInit() {

    if (this.dspcExplorerDataProvider.registrarDetails !== undefined) {
      this.registrar = JSON.parse(this.dspcExplorerDataProvider.registrarDetails);
      this.localStorageService.storeOnLocalStorage(this.REGISTRAR_KEY, this.registrar);
    } else {
      this.registrar = JSON.parse(this.localStorageService.getFromLocalStorage(this.REGISTRAR_KEY));
    }
    this.isAdmin = false;
  }

  getIsAdmin(): boolean {
    return this.isAdmin;
  }

  setIsAdmin(isAdmin: boolean): void {
    this.isAdmin = isAdmin;
  }

  getDate() {
    var date : Date = new Date(this.registrar.deathDate);
    return date.getDate() + "/" + (date.getMonth()+1) + "/" + date.getFullYear();
  }

}
