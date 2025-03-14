import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ReadCouleur} from '../Models/Couleur/ReadCouleur';
import {apiurl} from '../Config/APICONFIG';

@Injectable({
   providedIn: 'root'
})
export class CouleurService {

   constructor(private httpClient: HttpClient) {
   }
   getAllCouleurs():Observable<ReadCouleur[]>{
      return this.httpClient.get<ReadCouleur[]>(apiurl+"couleurs");
   }

}
