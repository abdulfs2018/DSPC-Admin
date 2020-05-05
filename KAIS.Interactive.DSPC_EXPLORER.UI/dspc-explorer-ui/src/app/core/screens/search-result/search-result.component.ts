import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {

  @Input('title') title: string;
  @Input('subtitle') subtitle: string;
  @Input('results') results: Array<Array<string>>;

  display: boolean = false;
  public toggleDisplay() {
    this.display = !this.display;
  }

  constructor() { 
    this.title = "Search Results";
    this.subtitle = "Click a Grave for More Details";
    this.results = [["Grave 1", "Killian Logan", "6", "D"],["Grave 2", "Jerry Coleman", "3", "S"],["Grave 3","Dermot", "9", "T"],["Grave 4","Frank Drebin","12","Q"]];
  }

  ngOnInit() {
  }

}
