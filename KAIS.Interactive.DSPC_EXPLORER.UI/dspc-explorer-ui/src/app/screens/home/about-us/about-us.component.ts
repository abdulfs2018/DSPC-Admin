import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-about-us",
  templateUrl: "./about-us.component.html",
  styleUrls: ["./about-us.component.scss"],
})
export class AboutUsComponent implements OnInit {
  constructor() {}

  ngOnInit() {}

  openModal(event) {
    var elem = document.getElementById("img01");
    var target = event.target || event.srcElement || event.currentTarget;
    elem.setAttribute("src", target.src);
    document.getElementById("myModal").style.display = "block";
  }

  closeModal() {
    document.getElementById("myModal").style.display = "none";
  }
}
