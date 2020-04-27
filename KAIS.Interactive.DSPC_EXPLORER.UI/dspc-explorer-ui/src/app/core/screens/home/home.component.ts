import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  readonly style = "style";

  counter(i: number) {
    return new Array(i);
  }

  toggleDivs(selectorA, selectorB) {
    let containerA: HTMLElement = document.getElementById(selectorA);
    let containerB: HTMLElement = document.getElementById(selectorB);

    console.log(containerA.getAttribute(this.style));

    if (containerA.getAttribute(this.style) === "display:block;") {
      containerA.setAttribute(this.style, "display:none;");
      containerB.setAttribute(this.style, "display:block;");
    } else {
      containerA.setAttribute(this.style, "display:block;");
      containerB.setAttribute(this.style, "display:none;");
    }
  }

}
