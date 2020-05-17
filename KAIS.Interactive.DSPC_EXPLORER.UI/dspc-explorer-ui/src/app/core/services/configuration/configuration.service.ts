import { Injectable } from "@angular/core";

import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class ConfigurationService {
  constructor() {}

  public get apiVersion(): string {
    return environment.apiVersion;
  }

  public get baseApiURL(): string {
    return environment.api.baseApiUrl;
  }

  public get baseURL(): string {
    return environment.baseUrl;
  }
}
