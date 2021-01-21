import * as _ from "underscore";
import { Component, OnInit } from "@angular/core";
import { RegistrarDTO } from "src/app/core/dtos/registrar.model";
import { DSPCExplorerDataProvider } from "src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service";
import { DSPCExplorerLocalStorageProvider } from "src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider";
import { SearchResultViewModel } from "src/app/core/models/search-results.model";
import { FormBuilder } from "@angular/forms";
import { SearchFilterDTO } from 'src/app/core/dtos/searchfilter.model';

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

  FirstName:string = "";
  LastName:string = "Crilly";


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

  }

  searchGraveRecords(): void {
    let requestBody: SearchFilterDTO = {
      FirstName: this.searchForm.get("firstName").value,
      LastName: this.searchForm.get("lastName").value,
      Sex: "",
      Age: 0,
      AgeDetail: "",
      Religion: "",
      Occupation: this.searchForm.get("occupation").value,
      DeathLocation: "",
      MarriageStatus: "",
      GraveOwnerName: this.searchForm.get("ownerName").value,
      GraveOwnerAddress: this.searchForm.get("ownerAddress").value,
      GraveSize: ""
    }

    this.dspcDataProvider.SearchRecords(requestBody).subscribe(data => {
      this.filterAndPopulateSearchResult(data);
    })

  }

  filterAndPopulateSearchResult(registrarArray: Array<RegistrarDTO>): void {
    var graveRefences: Array<string> = [];
    this.graveFilteredResults = new Array<SearchResultViewModel>();
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

  public displaySearchResults(): void {
    
    this.localStorageService.deleteFromLocalStorage(this.SEARCH_KEY);
    this.display = true;

    this.localStorageService.storeOnLocalStorage(
      this.SEARCH_KEY,
      this.graveFilteredResults
    );

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
