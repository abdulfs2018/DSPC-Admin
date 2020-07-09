import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { ConfigurationService } from "../configuration/configuration.service";
import { RegistrarDTO } from '../../dtos/registrar.model';
import { SearchFilterDTO } from '../../dtos/searchfilter.model';

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

  public getRegistrarDetailsById(Id: number): Observable<RegistrarDTO> {
    return this.httpClient.get<RegistrarDTO>(`${this.configuration.baseApiURL}/Registrar/getregistrardetailsbyId?Id=${Id}`);
  }


  public SearchRecords(searchFilter: SearchFilterDTO): Observable<Array<RegistrarDTO>> {
    return this.httpClient.post<Array<RegistrarDTO>>(`${this.configuration.baseApiURL}/GraveOwner/SearchGraveDetailsByFilterData`, searchFilter);
  }
}
