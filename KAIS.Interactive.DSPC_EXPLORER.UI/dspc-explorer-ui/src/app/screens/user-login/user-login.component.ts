import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {

  contact: { name: string; pass: string;}

  constructor() { 
    
    this.contact = {
      name: 'userName',
      pass: 'passWord'
    };

  }

  ngOnInit() {
  }

  createContact() {
    return true;
  }

}
