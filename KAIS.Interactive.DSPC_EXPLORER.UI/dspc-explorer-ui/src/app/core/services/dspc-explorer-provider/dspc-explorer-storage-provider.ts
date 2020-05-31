import { Inject, Injectable } from '@angular/core';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';

// key that is used to access the data in local storage
const SEARCH_KEY = 'local_search';


@Injectable()
export class DSPCExplorerLocalStorageProvider {

     
     

     constructor(@Inject(LOCAL_STORAGE) private storage: StorageService) { }


     public storeOnLocalStorage(key: string ,data: any): void {
          
          
          //const currentTodoList = this.storage.get(SEARCH_KEY) || [];
          
          //const currentSearch = [];

          //currentSearch.push({
          //    data: data,
          //});


          // insert updated array to local storage
          this.storage.set(SEARCH_KEY, data);
          
     }

     public getFromLocalStorage(key : string):  any {
          console.log(this.storage.get(key) || 'Local storage is empty');
          return this.storage.get(SEARCH_KEY);
     }

    /* returns boolean, true if deleted, false if not, undefined keys also return true that it is deleted */
     public deleteFromLocalStorage(key: string): boolean {
          this.storage.remove(key);
          return this.storage.get(key) == undefined;
     }

}