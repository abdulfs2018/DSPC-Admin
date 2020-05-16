import { Component, OnInit } from '@angular/core';
import { RegistrarDTO } from 'src/app/core/dtos/registrar.model';
import { Observable } from 'rxjs';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {


  display: boolean = false;
  registrars: Array<RegistrarDTO>;

  constructor(private dspcDataProvider: DSPCExplorerDataProvider) { }

  ngOnInit() {
    this.dspcDataProvider.getRegistrar().subscribe(data => {
      this.registrars = data;
      console.log(data);
    });


  }

  readonly style = "style";

  public toggleDisplay() {
    this.display = !this.display;
  }

  counter(i: number) {
    return new Array(i);
  }

  toggleDivs(selectorA, selectorB, selectorC, selectorD) {
    let containerA: HTMLElement = document.getElementById(selectorA);
    let containerB: HTMLElement = document.getElementById(selectorB);
    let buttonA: HTMLElement = document.getElementById(selectorC);
    let buttonB: HTMLElement = document.getElementById(selectorD);

    if (containerA.getAttribute(this.style) === "display:block;") {
      containerA.setAttribute(this.style, "display:none;");
      containerB.setAttribute(this.style, "display:block;");
      buttonA.setAttribute(this.style, "display:none;");
      buttonB.setAttribute(this.style, "display:block;");
    } else {
      containerA.setAttribute(this.style, "display:block;");
      containerB.setAttribute(this.style, "display:none;");
      buttonA.setAttribute(this.style, "display:block;");
      buttonB.setAttribute(this.style, "display:none;");
    }
  }

}
