import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { map } from "rxjs/operators";
import { ApiWrapperService } from "../api-wrapper/api-wrapper.service";
import { RegistrarDTO } from '../../dtos/registrar.model';

@Injectable({
  providedIn: "root",
})
export class DSPCExplorerDataProvider {
  constructor(private apiWrapperService: ApiWrapperService) { }

  graveDetails;

  public getRegistrar(): Observable<Array<RegistrarDTO>> {
    return this.apiWrapperService.getRegistrars().pipe();
  }
}
