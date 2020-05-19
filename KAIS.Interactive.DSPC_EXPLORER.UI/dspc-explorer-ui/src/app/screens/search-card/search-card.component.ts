import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';

@Component({
  selector: 'app-search-card',
  templateUrl: './search-card.component.html',
  styleUrls: ['./search-card.component.scss']
})
export class SearchCardComponent implements OnInit {

  @Input('result') result: string;
  @Input('image') image: string;
  arrResult: Array<string>;

  constructor(private dspcExplorerDataProvider: DSPCExplorerDataProvider, private route : Router) {
    this.image = "200x200.png";
    this.result = "";
   }

  ngOnInit() {
    this.arrResult = this.result.split(",");
    this.dspcExplorerDataProvider.graveDetails = this.arrResult;
  }

}
