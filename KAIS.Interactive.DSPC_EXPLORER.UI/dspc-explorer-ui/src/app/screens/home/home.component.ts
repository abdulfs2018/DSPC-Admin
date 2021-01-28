import * as _ from "underscore";
import { Component, OnInit } from "@angular/core";
import { RegistrarDTO } from "src/app/core/dtos/registrar.model";
import { DSPCExplorerDataProvider } from "src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service";
import { DSPCExplorerLocalStorageProvider } from "src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider";
import { SearchResultViewModel } from "src/app/core/models/search-results.model";
import { FormBuilder } from "@angular/forms";
import { SearchFilterDTO } from 'src/app/core/dtos/searchfilter.model';
import { Router } from "@angular/router";

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
    private fb: FormBuilder,
    private router: Router
  ) {
    this.display =
      this.localStorageService.getFromLocalStorage(this.SEARCH_KEY) !==
      undefined;
    
    this.graveFilteredResults = new Array<SearchResultViewModel>();
  }

  ngOnInit() {
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  searchGraveRecords(): void {
    this.graveFilteredResults = new Array<SearchResultViewModel>();

    let requestBody: SearchFilterDTO = {
      FirstName: (<HTMLInputElement>document.getElementById("firstName")).value != null ? (<HTMLInputElement>document.getElementById("firstName")).value : "",
      LastName: (<HTMLInputElement>document.getElementById("lastName")).value != null ? (<HTMLInputElement>document.getElementById("lastName")).value : "",
      Sex: (<HTMLInputElement>document.getElementById("gender")).value != null ? (<HTMLInputElement>document.getElementById("gender")).value : "",
      Age: (<HTMLInputElement>document.getElementById("age")).value != "Select Age" ? Number.parseInt((<HTMLInputElement>document.getElementById("age")).value) : 0,
      AgeDetail: "",
      Religion: (<HTMLInputElement>document.getElementById("religion")).value != null ? (<HTMLInputElement>document.getElementById("religion")).value : "",
      Occupation: (<HTMLInputElement>document.getElementById("occupation")).value != null ? (<HTMLInputElement>document.getElementById("occupation")).value : "",
      DeathLocation: "",
      MarriageStatus: "",
      GraveOwnerName: "",
      GraveOwnerAddress: "",
      GraveSize: "",
    }
    
    this.dspcDataProvider.SearchRecords(requestBody).subscribe(data => {
      this.filterAndPopulateSearchResult(data);
    })
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
          imageSource: "grave-headstone-sample.png",
          graveCoordinates: e.graveOwner.graveLocation,
          graveSection: e.graveOwner.section.code
        };
        this.graveFilteredResults.push(searchData);
        
      }
    });

    this.localStorageService.storeOnLocalStorage(
      this.SEARCH_KEY,
      this.graveFilteredResults
    );
    this.router.navigate(["."]);
  }

  public advanceSearchToggle(): void {
    var x = document.getElementById("advanceSearch");
    if (x.style.display === "none") {
      x.style.display = "block";
    } else {
      x.style.display = "none";
    }
  }

  public displaySearchResults(): void {
    this.display = true;
  }

  counter(i: number) {
    return new Array(i);
  }

  toggleDivs(selectorA, selectorB): void {
    let containerA: HTMLElement = document.getElementById(selectorA);
    let containerB: HTMLElement = document.getElementById(selectorB);

    if (containerA.getAttribute(this.style) === "display: block;") {
      containerA.setAttribute(this.style, "display: none;");
      containerB.setAttribute(this.style, "display: block;");
    } else {
      containerA.setAttribute(this.style, "display: block;");
      containerB.setAttribute(this.style, "display: none;");
    }
  }
}
