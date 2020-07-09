import * as _ from "underscore";
import { Component, OnInit } from "@angular/core";
import { RegistrarDTO } from "src/app/core/dtos/registrar.model";
import { DSPCExplorerDataProvider } from "src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service";
import { DSPCExplorerLocalStorageProvider } from "src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider";
import { SearchResultViewModel } from "src/app/core/models/search-results.model";
import { FormBuilder } from "@angular/forms";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
})
export class HomeComponent implements OnInit {
  graveFilteredResults: Array<SearchResultViewModel>;
  display: boolean = false;
  readonly style = "style";
  readonly SEARCH_KEY = "local_search";

  gender: string[] = ["Male", "Female"];
  religion: string[] = ["Roman Catholic", "Protestant"];
  graveSize: string[] = ["Single", "Double", "Triple", "Quadruple", "Large"];

  searchForm = this.fb.group({
    firstName: [""],
    lastName: [""],
    occupation: [""],
    registrarName: [""],
    gender: [this.gender],
    age: [""],
    religion: [this.religion],
    deathDate: [""],
    burialDate: [""],
    referenceCode: [""],
    graveSize: [this.graveSize],
    ownerName: [""],
    ownerAddress: [""],
  });

  constructor(
    private dspcDataProvider: DSPCExplorerDataProvider,
    private localStorageService: DSPCExplorerLocalStorageProvider,
    private fb: FormBuilder
  ) {
    this.display =
      this.localStorageService.getFromLocalStorage(this.SEARCH_KEY) !==
      undefined;
    this.graveFilteredResults = new Array<SearchResultViewModel>();
  }

  ngOnInit() {
    this.dspcDataProvider.getRegistrar().subscribe((data) => {
      this.filterAndPopulateSearchResult(data);
    });
  }

  filterAndPopulateSearchResult(registrarArray: Array<RegistrarDTO>): void {
    var graveRefences: Array<string> = [];
    registrarArray.forEach((e) => {
      if (graveRefences.indexOf(e.graveOwner.graveReferenceCode) == -1) {
        graveRefences.push(e.graveOwner.graveReferenceCode);

        let searchData: SearchResultViewModel = {
          graveownerName: e.graveOwner.graveOwnerName,
          graveRefCode: e.graveOwner.graveReferenceCode,
          buttonText: "View Selected Grave Details",
          graveSize: e.graveOwner.graveSize,
          imageSource: "grave-headstone-sample.jpg",
        };

        this.graveFilteredResults.push(searchData);
      }
    });
  }

  public advanceSearchToggle(): void {
    var x = document.getElementById("advanceSearch");
    if (x.style.display === "none") {
      x.style.display = "block";
    } else {
      x.style.display = "none";
    }
  }

  public toggleDisplay(): void {
    this.display = !this.display;

    if (this.display) {
      this.localStorageService.storeOnLocalStorage(
        this.SEARCH_KEY,
        this.graveFilteredResults
      );
    } else {
      this.localStorageService.deleteFromLocalStorage(this.SEARCH_KEY);
    }
  }

  counter(i: number) {
    return new Array(i);
  }

  toggleDivs(selectorA, selectorB): void {
    let containerA: HTMLElement = document.getElementById(selectorA);
    let containerB: HTMLElement = document.getElementById(selectorB);

    if (containerA.getAttribute(this.style) === "display:block;") {
      containerA.setAttribute(this.style, "display:none;");
      containerB.setAttribute(this.style, "display:block;");
    } else {
      containerA.setAttribute(this.style, "display:block;");
      containerB.setAttribute(this.style, "display:none;");
    }
  }
}
