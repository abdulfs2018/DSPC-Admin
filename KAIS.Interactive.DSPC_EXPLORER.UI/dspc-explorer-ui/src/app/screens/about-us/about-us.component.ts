import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-about-us",
  templateUrl: "./about-us.component.html",
  styleUrls: ["./about-us.component.scss"],
})
export class AboutUsComponent implements OnInit {
  constructor() {}

  ngOnInit() {}

  // showModalImg(e){}
  openModal(event) {

    var target = event.target || event.srcElement || event.currentTarget;    
    document.getElementById("img01").setAttribute("src",target.src);
    document.getElementById("myModal").style.display = "block";
  }

  closeModal() {
    document.getElementById("myModal").style.display = "none";
  }


}