import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-grave-details',
  templateUrl: './grave-details.component.html',
  styleUrls: ['./grave-details.component.scss']
})
export class GraveDetailsComponent implements OnInit {

  constructor(private route : ActivatedRoute) { }

  graveInfo: any;

  ngOnInit() {
    this.graveInfo = this.route.snapshot.params;
  }

}
