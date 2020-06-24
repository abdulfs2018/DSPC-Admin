import { Component, OnInit } from '@angular/core';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';


@Component({
  selector: 'app-grave-registrars',
  templateUrl: './grave-registrars.component.html',
  styleUrls: ['./grave-registrars.component.scss']
})
export class GraveRegistrarsComponent implements OnInit {

  constructor(private dspcExplorerDataProvider: DSPCExplorerDataProvider, private localStorageService: DSPCExplorerLocalStorageProvider) { }

  arrResult : any;
  private isAdmin: boolean;
  readonly REGISTRAR_KEY = "local_registar";

  ngOnInit() {
    
    if (this.dspcExplorerDataProvider.registrarDetails !== undefined) {
      this.arrResult = this.dspcExplorerDataProvider.registrarDetails;
      this.localStorageService.storeOnLocalStorage(this.REGISTRAR_KEY, this.arrResult);
    } else {
      this.arrResult = this.localStorageService.getFromLocalStorage(this.REGISTRAR_KEY);
    } 
    this.isAdmin = false;
  }

  getIsAdmin(): boolean {
    return this.isAdmin;
  }

  setIsAdmin(isAdmin: boolean): void {
    this.isAdmin = isAdmin;
  }

}
