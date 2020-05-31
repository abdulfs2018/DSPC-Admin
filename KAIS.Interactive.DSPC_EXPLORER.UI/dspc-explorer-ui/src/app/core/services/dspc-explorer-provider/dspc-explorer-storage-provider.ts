import { Inject, Injectable } from '@angular/core';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';

@Injectable()
export class DSPCExplorerLocalStorageProvider {

     constructor(@Inject(LOCAL_STORAGE) private storage: StorageService) { }


     public storeOnLocalStorage(key: string ,data: any): boolean {
          this.storage.set(key, data);
          return this.storage.get(key) !== undefined;
     }

     public getFromLocalStorage(key : string):  any {
          console.log(this.storage.get(key) || 'Local storage is empty');
          return this.storage.get(key);
     }

     public deleteFromLocalStorage(key: string): boolean {
          this.storage.remove(key);
          return this.storage.get(key) === undefined;
     }

}