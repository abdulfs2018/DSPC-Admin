import { Component, OnInit, Input } from '@angular/core';
import { Router} from '@angular/router';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';

@Component({
  selector: 'app-grave-details-registrars',
  templateUrl: './grave-details-registrars.component.html',
  styleUrls: ['./grave-details-registrars.component.scss']
})
export class GraveDetailsRegistrarsComponent implements OnInit {

  constructor(private dspcExplorerDataProvider: DSPCExplorerDataProvider, private router: Router) { }

  @Input('result') result: string;
  arrResult : Array<string>;
  private isAdmin : boolean;

  ngOnInit() {
    this.arrResult = this.result.split(",");
    this.isAdmin = false;
    this.dspcExplorerDataProvider.registrarDetails = this.arrResult;
  }

}
