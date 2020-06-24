import { Component, OnInit, Input } from '@angular/core';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {

  @Input('image') image: string;
  @Input('title') title: string;
  @Input('subtitle') subtitle: string;
  @Input('results') results: Array<Array<string>>;


  pageSize: number=5;
  page: number=1;


  constructor(private localStorageService: DSPCExplorerLocalStorageProvider) { 
    this.image = "200x200.png";
    this.title = "Search Results";
    this.subtitle = "Click a Grave for More Details";
  }

  ngOnInit() {
    this.results = this.localStorageService.getFromLocalStorage('local_search');
  }

}
