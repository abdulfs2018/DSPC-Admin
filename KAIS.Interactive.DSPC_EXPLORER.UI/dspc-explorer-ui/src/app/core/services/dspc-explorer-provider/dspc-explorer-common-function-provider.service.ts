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
export class DSPCExplorerCommonFunctionProvider {
  constructor(private apiWrapperService: ApiWrapperService) { }

  public graveSizeTextFromletter(graveSizeLetter : string): string {
    
    switch(graveSizeLetter.toLowerCase()) {
      case 's':
        return 'Single';
      case 'd':
        return 'Double';
      case 't':
        return 'Triple';  
      case 'q':
        return 'Quadruple';
      case 'l':
        return 'Large';
      default:
        return graveSizeLetter;
    }

    
  }

  
}
