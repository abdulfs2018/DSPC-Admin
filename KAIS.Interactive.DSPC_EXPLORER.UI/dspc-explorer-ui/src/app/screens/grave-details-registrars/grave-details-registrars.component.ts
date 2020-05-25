import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-grave-details-registrars',
  templateUrl: './grave-details-registrars.component.html',
  styleUrls: ['./grave-details-registrars.component.scss']
})
export class GraveDetailsRegistrarsComponent implements OnInit {

  constructor() { }

  @Input('result') result: string;
  arrResult : Array<string>

  ngOnInit() {
    this.arrResult = this.result.split(",");
  }

}
