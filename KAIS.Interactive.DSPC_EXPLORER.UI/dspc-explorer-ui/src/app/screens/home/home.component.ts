import { Component, OnInit } from '@angular/core';
import { RegistrarDTO } from 'src/app/core/dtos/registrar.model';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {

    searchResults: Array<Array<string>>;
    formData: any;
    display: boolean = false;
    registrars: Array<RegistrarDTO>;
    readonly style = "style";
    readonly SEARCH_KEY = "local_search";

    constructor(private dspcDataProvider: DSPCExplorerDataProvider, private localStorageService: DSPCExplorerLocalStorageProvider) {
      this.display = this.localStorageService.getFromLocalStorage(this.SEARCH_KEY) !== undefined;
    }

    ngOnInit() {
      this.dspcDataProvider.getRegistrar().subscribe(data => {
        this.registrars = data;
      });

      this.searchResults = 
      [
        ["1", "Grave 1", "Killian Logan", "6", "D"],["2","Grave 2", "Jerry Coleman", "3", "S"],["3", "Grave 3", "Dermot", "9", "T"],["4", "Grave 4", "Frank Drebin", "12" ,"Q"],
        ["5", "Grave 1", "Killian Logan", "6", "D"],["6","Grave 2", "Jerry Coleman", "3", "S"],["7", "Grave 3", "Dermot", "9", "T"],["8", "Grave 4", "Frank Drebin", "12" ,"Q"],
        ["9", "Grave 1", "Killian Logan", "6", "D"],["10","Grave 2", "Jerry Coleman", "3", "S"],["11", "Grave 3", "Dermot", "9", "T"],["12", "Grave 4", "Frank Drebin", "12" ,"Q"],
        ["13", "Grave 1", "Killian Logan", "6", "D"],["14","Grave 2", "Jerry Coleman", "3", "S"],["15", "Grave 3", "Dermot", "9", "T"],["16", "Grave 4", "Frank Drebin", "12" ,"Q"],
        ["17", "Grave 1", "Killian Logan", "6", "D"],["18","Grave 2", "Jerry Coleman", "3", "S"],["19", "Grave 3", "Dermot", "9", "T"],["20", "Grave 4", "Frank Drebin", "12" ,"Q"]
      ];
    
  }

  

  public toggleDisplay() {
    this.display = !this.display;

    if (this.display) {
      this.localStorageService.storeOnLocalStorage(this.SEARCH_KEY, this.searchResults);
    } else {
      this.localStorageService.deleteFromLocalStorage(this.SEARCH_KEY);
    }

  }

  counter(i: number) {
    return new Array(i);
  }

  toggleDivs(selectorA, selectorB, selectorC, selectorD) {
    let containerA: HTMLElement = document.getElementById(selectorA);
    let containerB: HTMLElement = document.getElementById(selectorB);
    let buttonA: HTMLElement = document.getElementById(selectorC);
    let buttonB: HTMLElement = document.getElementById(selectorD);

    if (containerA.getAttribute(this.style) === "display:block;") {
      containerA.setAttribute(this.style, "display:none;");
      containerB.setAttribute(this.style, "display:block;");
      buttonA.setAttribute(this.style, "display:none;");
      buttonB.setAttribute(this.style, "display:block;");
    } else {
      containerA.setAttribute(this.style, "display:block;");
      containerB.setAttribute(this.style, "display:none;");
      buttonA.setAttribute(this.style, "display:block;");
      buttonB.setAttribute(this.style, "display:none;");
    }
  }

}
