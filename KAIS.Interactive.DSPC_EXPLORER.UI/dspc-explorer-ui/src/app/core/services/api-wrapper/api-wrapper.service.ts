import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { ConfigurationService } from "../configuration/configuration.service";
import { RegistrarDTO } from '../../dtos/registrar.model';
import { SearchFilterDTO } from '../../dtos/searchfilter.model';
import { GraveOwnerDTO } from '../../dtos/graveowner.model';
import { GraveOwnerRegistrarsDTO } from '../../dtos/graveownerRegistrars.model';

@Injectable({
  providedIn: "root",
})
export class ApiWrapperService {
  constructor(
    private httpClient: HttpClient,
    private configuration: ConfigurationService
  ) { }


  public getRegistrars(): Observable<Array<RegistrarDTO>> {
    return this.httpClient.get<Array<RegistrarDTO>>(`${this.configuration.baseApiURL}/Registrar/getallregistrar`);
  }

  public SearchRecords(searchFilter: SearchFilterDTO): Observable<Array<RegistrarDTO>> {
    return this.httpClient.post<Array<RegistrarDTO>>(`${this.configuration.baseApiURL}/GraveOwner/SearchGraveDetailsByFilterData`, searchFilter);
  }

  public GetGraveRegistrars(graveRefCode: string): Observable<GraveOwnerRegistrarsDTO> {
    return this.httpClient.get<GraveOwnerRegistrarsDTO>(`${this.configuration.baseApiURL}/GraveOwner/GetGraveOwnerDetailsByCode?code=${graveRefCode}`);
  }

}
