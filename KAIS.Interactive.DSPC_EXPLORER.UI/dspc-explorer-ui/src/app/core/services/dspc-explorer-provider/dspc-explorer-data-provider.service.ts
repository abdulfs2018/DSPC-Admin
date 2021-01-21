import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { ApiWrapperService } from "../api-wrapper/api-wrapper.service";
import { RegistrarDTO } from '../../dtos/registrar.model';
import { SearchFilterDTO } from '../../dtos/searchfilter.model';
import { GraveOwnerDTO } from '../../dtos/graveowner.model';
import { GraveOwnerRegistrarsDTO } from '../../dtos/graveownerRegistrars.model';

@Injectable({
  providedIn: "root",
})
export class DSPCExplorerDataProvider {
  constructor(private apiWrapperService: ApiWrapperService) { }

  public getRegistrar(): Observable<Array<RegistrarDTO>> {
    return this.apiWrapperService.getRegistrars().pipe();
  }

  public getSimpleSearchRegistrar(FirstName : string, LastName: string): Observable<Array<RegistrarDTO>> {
    return this.apiWrapperService.getSimpleSearchRegistrars(FirstName, LastName).pipe();
  }

  public getRegistrarDetailsById(Id: number): Observable<RegistrarDTO> {
    return this.apiWrapperService.getRegistrarDetailsById(Id).pipe();
  }

  public SearchRecords(searchFilter: SearchFilterDTO): Observable<Array<RegistrarDTO>> {
    return this.apiWrapperService.SearchRecords(searchFilter);
  }

  public getGraveRegistrars(graveRefCode: string): Observable<GraveOwnerRegistrarsDTO> {
    return this.apiWrapperService.GetGraveRegistrars(graveRefCode);
  }
}
