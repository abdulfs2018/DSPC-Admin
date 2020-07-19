import { Component, OnInit, Input, OnChanges, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-custom-loader',
  templateUrl: './custom-loader.component.html',
  styleUrls: ['./custom-loader.component.scss']
})
export class CustomLoaderComponent implements OnInit, OnChanges, OnDestroy {

  @Input('subject') subject: string;
  @Input('strokeWidth') strokeWidth: string;
  @Input('diameter') diameter: string;

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges() {
  }

  ngOnDestroy() {
  }

}