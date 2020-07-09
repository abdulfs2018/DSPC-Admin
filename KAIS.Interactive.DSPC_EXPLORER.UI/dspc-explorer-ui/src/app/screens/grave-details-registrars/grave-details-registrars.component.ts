import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { DSPCExplorerDataProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-data-provider.service';
import { RegistrarDTO } from 'src/app/core/dtos/registrar.model';

@Component({
  selector: 'app-grave-details-registrars',
  templateUrl: './grave-details-registrars.component.html',
  styleUrls: ['./grave-details-registrars.component.scss']
})
export class GraveDetailsRegistrarsComponent implements OnInit {

  constructor(private dspcExplorerDataProvider: DSPCExplorerDataProvider, private router: Router) { }

  @Input('result') result: string;
  registrar : RegistrarDTO;
  private isAdmin : boolean;

  ngOnInit() {
    this.registrar = JSON.parse(this.result);
    this.isAdmin = false;
  }

  showRegistrarDetails() {
    this.dspcExplorerDataProvider.registrarDetails = this.result;
    this.router.navigate(['../graveRegistrars']);
  }

  getIsAdmin(): boolean {
    return this.isAdmin;
  }

  setIsAdmin(isAdmin: boolean): void {
    this.isAdmin = isAdmin;
  }

  getDate() {
    var date : Date = new Date(this.registrar.deathDate);
    return date.getDate() + "/" + (date.getMonth()+1) + "/" + date.getFullYear();
  }

}
