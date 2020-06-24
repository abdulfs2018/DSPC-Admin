import { Component, OnInit } from '@angular/core';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';

@Component({
  selector: 'app-grave-details',
  templateUrl: './grave-details.component.html',
  styleUrls: ['./grave-details.component.scss']
})
export class GraveDetailsComponent implements OnInit {

  constructor(private dspcExplorerDataProvider : DSPCExplorerDataProvider,  private localStorageService: DSPCExplorerLocalStorageProvider) { }

  private graveInfo: any;
  private results: any;
  private isAdmin : boolean;
  readonly GRAVE_KEY = "local_grave";

  ngOnInit() {

    if (this.dspcExplorerDataProvider.graveDetails !== undefined) {
      this.graveInfo = this.dspcExplorerDataProvider.graveDetails;
      this.localStorageService.storeOnLocalStorage(this.GRAVE_KEY, this.graveInfo);
    } else {
      this.graveInfo = this.localStorageService.getFromLocalStorage(this.GRAVE_KEY);
    }
  
    this.isAdmin = false;
    
    this.results = [
      [
        "1", "John Prescott", "5 APR 1941", "20 MAR 2020"
      ],
      [
        "2", "Emily Prescott", "10 DEC 1941", "15 MAR 1990"
      ]
    ]
    this.dspcExplorerDataProvider.registrarDetails = this.results;
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

  getResults(): any {
    return this.results;
  }

  setResults(results: any): void {
    this.results = results;
  }
  

}
