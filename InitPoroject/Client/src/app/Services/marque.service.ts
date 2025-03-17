import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ReadMarque} from '../Models/Marque/ReadMarque';
import {apiurl} from '../Config/APICONFIG';

@Injectable({
   providedIn: 'root'
})
export class MarqueService {

   constructor(private httpClient: HttpClient) {

   }
   getAllMarques():Observable<ReadMarque[]>{
      return this.httpClient.get<ReadMarque[]>(apiurl+"marques");
   }
}
