import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { ApiWrapperService } from "../api-wrapper/api-wrapper.service";
import { RegistrarDTO } from '../../dtos/registrar.model';
import { SearchFilterDTO } from '../../dtos/searchfilter.model';

@Injectable({
  providedIn: "root",
})
export class DSPCExplorerDataProvider {
  constructor(private apiWrapperService: ApiWrapperService) { }

  graveDetails;
  registrarDetails;

  public getRegistrar(): Observable<Array<RegistrarDTO>> {
    return this.apiWrapperService.getRegistrars().pipe();
  }

  public getRegistrarDetailsById(Id: number): Observable<RegistrarDTO> {
    return this.apiWrapperService.getRegistrarDetailsById(Id).pipe();
  }

  public SearchRecords(searchFilter: SearchFilterDTO): Observable<Array<RegistrarDTO>> {
    return this.apiWrapperService.SearchRecords(searchFilter);
  }
}
