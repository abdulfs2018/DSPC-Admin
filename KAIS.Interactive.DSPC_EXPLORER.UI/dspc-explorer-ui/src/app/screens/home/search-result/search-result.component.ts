import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';
import { SearchResultViewModel } from 'src/app/core/models/search-results.model';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {

  @Input('title') title: string;
  @Input('subtitle') subtitle: string;
  apiResults: Array<SearchResultViewModel>;
  pageSize: number = 5;
  page: number = 1;
  readonly SEARCH_KEY = "local_search";
  readonly GRAVE_KEY = "local_grave";
  
  constructor(private localStorageService: DSPCExplorerLocalStorageProvider,  private router: Router) { 
  }

  ngOnInit() {
    this.apiResults = this.localStorageService.getFromLocalStorage(this.SEARCH_KEY);
  }

  showGraveDetailResult(result: Array<string>) : void {
    this.localStorageService.storeOnLocalStorage(this.GRAVE_KEY, result);
    this.router.navigate(['../graveDetails']);
  }
}
