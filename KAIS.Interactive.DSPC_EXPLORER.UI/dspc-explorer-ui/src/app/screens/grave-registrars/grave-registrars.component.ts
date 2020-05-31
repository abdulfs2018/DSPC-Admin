import { Component, OnInit } from '@angular/core';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';

@Component({
  selector: 'app-grave-registrars',
  templateUrl: './grave-registrars.component.html',
  styleUrls: ['./grave-registrars.component.scss']
})
export class GraveRegistrarsComponent implements OnInit {

  constructor(private dspcExplorerDataProvider: DSPCExplorerDataProvider) { }

  arrResult : any;
  private isAdmin: boolean;

  ngOnInit() {
    this.arrResult = this.dspcExplorerDataProvider.registrarDetails;
    this.isAdmin = false;
  }

}
