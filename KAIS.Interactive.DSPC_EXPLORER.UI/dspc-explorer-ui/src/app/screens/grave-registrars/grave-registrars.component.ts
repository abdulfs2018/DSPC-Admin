import { Component, OnInit } from '@angular/core';
import { DSPCExplorerLocalStorageProvider } from 'src/app/core/services/dspc-explorer-provider/dspc-explorer-storage-provider';
import { RegistrarDTO } from 'src/app/core/dtos/registrar.model';

@Component({
  selector: 'app-grave-registrars',
  templateUrl: './grave-registrars.component.html',
  styleUrls: ['./grave-registrars.component.scss']
})
export class GraveRegistrarsComponent implements OnInit {

  constructor(private localStorageService: DSPCExplorerLocalStorageProvider) { }

  registrar : RegistrarDTO;
  private isAdmin: boolean;
  private labelOptions: object;
  private graveOwnerLastName: string;
  private gravePinImage : object;
  private entrancePinImage: object;
  readonly REGISTRAR_KEY = "local_registrar";

  ngOnInit() {
    this.registrar = this.localStorageService.getFromLocalStorage(this.REGISTRAR_KEY);
    this.graveOwnerLastName = this.registrar.graveOwner.graveOwnerName.split(" ")[1];
    this.gravePinImage = { 
      url : 'http://maps.google.com/mapfiles/ms/icons/red-dot.png', 
      labelOrigin:{x:22,y:-10}
    }

    this.entrancePinImage = { 
      url : 'http://maps.google.com/mapfiles/ms/icons/green-dot.png', 
      labelOrigin:{x:22,y:-10}
    }

    this.labelOptions = {
      color: 'black',
      fontFamily: '',
      fontSize: '14px',
      fontWeight: 'bold',
      text: this.graveOwnerLastName + ' Family Grave'
    }
    this.isAdmin = false;
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
