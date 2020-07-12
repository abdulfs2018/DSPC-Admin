import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';
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
  
  constructor(private dspcExplorerDataProvider: DSPCExplorerDataProvider, private localStorageService: DSPCExplorerLocalStorageProvider,  private router: Router) { 
  }

  ngOnInit() {
    this.apiResults = this.localStorageService.getFromLocalStorage(this.SEARCH_KEY);
    this.localStorageService.deleteFromLocalStorage(this.SEARCH_KEY);
  }

  showGraveDetailResult(result: Array<string>) : void {
    this.dspcExplorerDataProvider.graveDetails = result;
    this.router.navigate(['../graveDetails']);
  }
}
