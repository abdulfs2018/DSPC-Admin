import { Component, OnInit } from '@angular/core';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';
import { SearchResultViewModel } from "src/app/core/models/search-results.model";
import { GraveOwnerRegistrarsDTO } from 'src/app/core/dtos/graveownerRegistrars.model';

@Component({
  selector: 'app-grave-details',
  templateUrl: './grave-details.component.html',
  styleUrls: ['./grave-details.component.scss']
})
export class GraveDetailsComponent implements OnInit {

  constructor(private dspcExplorerDataProvider : DSPCExplorerDataProvider,  private localStorageService: DSPCExplorerLocalStorageProvider) { }

  private graveInfo: SearchResultViewModel;
  private results: GraveOwnerRegistrarsDTO;
  private isAdmin : boolean;
  readonly GRAVE_KEY = "local_grave";
  readonly REGISTRAR_KEY = "local_registrar";

  ngOnInit() {
    this.graveInfo = this.localStorageService.getFromLocalStorage(this.GRAVE_KEY);
    this.isAdmin = false;
  
    this.dspcExplorerDataProvider.getGraveRegistrars(this.graveInfo.graveRefCode).subscribe((data) => {
      this.results = data;
    });
  }

  showTab(tab: string) {
    let graveTab: HTMLElement = document.getElementById("grave-tab");
    let registrarTab: HTMLElement = document.getElementById("registrar-tab");

    if (tab == "grave") {
      graveTab.classList.add("selected");
      registrarTab.classList.remove("selected");
    } else if(tab == "registrar"){
      registrarTab.classList.add("selected");
      graveTab.classList.remove("selected");
    }

  }

  getAdmin(): boolean {
    return this.isAdmin;
  }

  setAdmin(isAdmin: boolean): void {
    this.isAdmin = isAdmin;
  }

  getGraveInfo(): any {
    return this.graveInfo;
  }

  setGraveInfo(graveInfo: any): void {
    this.graveInfo = graveInfo;
  }

  getResults(): Array<string> {

    var resultArr = [];

    if (this.results !== undefined) {
      this.results.registrars.forEach(data => {
        resultArr.push(JSON.stringify(data));
      });
    }
      
    return resultArr;
  }

  setResults(results: any): void {
    this.results = results;
  }
  

}
