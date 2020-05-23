import { Component, OnInit } from '@angular/core';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';

@Component({
  selector: 'app-grave-details',
  templateUrl: './grave-details.component.html',
  styleUrls: ['./grave-details.component.scss']
})
export class GraveDetailsComponent implements OnInit {

  constructor(private dspcExplorerDataProvider : DSPCExplorerDataProvider) { }

  private graveInfo: any;

  ngOnInit() {
    this.graveInfo = this.dspcExplorerDataProvider.graveDetails;
  }

  showTab(tab: string) {
    let graveTab: HTMLElement = document.getElementById("grave-tab");
    let registrarTab: HTMLElement = document.getElementById("registrar-tab");

    if (tab == "grave") {
      graveTab.classList.add("selected");
      registrarTab.classList.remove("selected");
    } else if(tab == "registrar"){
      registrarTab.classList.add("selected");
      graveTab.classList.remove("selected");
    }

  }

}
