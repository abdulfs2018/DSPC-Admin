import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-card',
  templateUrl: './search-card.component.html',
  styleUrls: ['./search-card.component.scss']
})
export class SearchCardComponent implements OnInit {

  @Input('result') result: string;
  @Input('image') image: string;
  arrResult: Array<string>;

  constructor(private route : Router) {
    this.image = "200x200.png";
    this.result = "";
   }

  ngOnInit() {
    this.arrResult = this.result.split(",");
  }

  openGraveDetails() {
    this.route.navigate(['../graveDetails', this.arrResult]);
  }

}
