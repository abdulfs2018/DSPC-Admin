import { Component, OnInit, Input } from '@angular/core';

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


  pageSize: Number=5;
  page: Number=1;


  constructor() { 
    this.image = "200x200.png";
    this.title = "Search Results";
    this.subtitle = "Click a Grave for More Details";
    this.results = 
    [
      ["1", "Grave 1", "Killian Logan", "6", "D"],["2","Grave 2", "Jerry Coleman", "3", "S"],["3", "Grave 3", "Dermot", "9", "T"],["4", "Grave 4", "Frank Drebin", "12" ,"Q"],
      ["5", "Grave 1", "Killian Logan", "6", "D"],["6","Grave 2", "Jerry Coleman", "3", "S"],["7", "Grave 3", "Dermot", "9", "T"],["8", "Grave 4", "Frank Drebin", "12" ,"Q"],
      ["9", "Grave 1", "Killian Logan", "6", "D"],["10","Grave 2", "Jerry Coleman", "3", "S"],["11", "Grave 3", "Dermot", "9", "T"],["12", "Grave 4", "Frank Drebin", "12" ,"Q"],
      ["13", "Grave 1", "Killian Logan", "6", "D"],["14","Grave 2", "Jerry Coleman", "3", "S"],["15", "Grave 3", "Dermot", "9", "T"],["16", "Grave 4", "Frank Drebin", "12" ,"Q"],
      ["17", "Grave 1", "Killian Logan", "6", "D"],["18","Grave 2", "Jerry Coleman", "3", "S"],["19", "Grave 3", "Dermot", "9", "T"],["20", "Grave 4", "Frank Drebin", "12" ,"Q"]
  ];

  }

  ngOnInit() {
  }

}
