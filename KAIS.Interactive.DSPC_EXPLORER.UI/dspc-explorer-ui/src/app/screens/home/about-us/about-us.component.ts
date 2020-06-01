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
    document.getElementById("img01").src = target.src;
    document.getElementById("myModal").style.display = "block";
  }

  closeModal() {
    document.getElementById("myModal").style.display = "none";
  }


}

// var AppModal = function ($scope, $modal, $log,$sce) {
//   var parentScope = $scope;

//   $scope.imgs =[];
//   $scope.imgs.push($sce.trustAsUrl("./assets/images/graveGate.jpg"));
//   $scope.imgs.push($sce.trustAsUrl("./assets/images/graveGate.jpg"));
//   $scope.imgs.push($sce.trustAsUrl("./assets/images/graveGate.jpgf"));

// $scope.openModalImage = function (imageSrc, imageDescription) {
//   $modal.open({
//     templateUrl: "../modal/modal.component.html",
//     backdrop: true,
//     windowClass: 'modal',
//     resolve: {
//         imageSrcToUse: function () {
//             return imageSrc;
//         },
//         imageDescriptionToUse: function () {
//             return imageDescription;
//         }
//     },
//     controller: function ($scope, $modalInstance) {
//       $scope.imgs = parentScope.imgs;
//       $scope.cancel = function () {
//           $modalInstance.dismiss('cancel');
//       };
//   }
//  });
// };
// };
