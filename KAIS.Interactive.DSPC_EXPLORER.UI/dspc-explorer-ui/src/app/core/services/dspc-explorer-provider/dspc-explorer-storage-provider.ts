import { Inject, Injectable } from '@angular/core';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';


// key that is used to access the data in local storage
const SEARCH_KEY = 'local_search';

@Injectable()
export class DSPCExplorerLocalStorageProvider {


     constructor(@Inject(LOCAL_STORAGE) private storage: StorageService) { }


     public storeOnLocalStorage(data: {[key: string]: Object}): void {
          
          
          //const currentTodoList = this.storage.get(SEARCH_KEY) || [];
          
          //const currentSearch = [];

          //currentSearch.push({
          //    data: data,
          //});


          // insert updated array to local storage
          this.storage.set(SEARCH_KEY, data);
          
     }

     public getFromLocalStorage():  {[key: string]: Object} {
        console.log(this.storage.get(SEARCH_KEY) || 'Local storage is empty');
        return this.storage.get(SEARCH_KEY) || [];
     
    }

}