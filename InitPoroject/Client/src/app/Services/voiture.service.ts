import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ReadVoitureDto} from '../Models/ReadVoitureDto';
import {apiurl} from '../Config/APICONFIG';
import {CreateVoitureDto} from '../Models/CreateVoitureDto';
import {FilterVoitureDto} from '../Models/FilterVoitureDto';
import {formatFilterQueryVoiture} from '../Helpers/QueryObjects/formatQueryVoiture';

@Injectable({
   providedIn: 'root'
})
export class VoitureService {
   constructor(private httpClient: HttpClient) {

   }

   getAllVoitures(filterVoitures: FilterVoitureDto | undefined): Observable<ReadVoitureDto[]> {
      let query = "";
      if(filterVoitures !== undefined)
         query  = formatFilterQueryVoiture(filterVoitures);
      console.log(filterVoitures);
      return this.httpClient.get<ReadVoitureDto[]>(apiurl + "voitures?"+query);
   }

   deleteVoiture(immatriculation: string): Observable<string> {
      return this.httpClient.delete<string>(apiurl + "voitures/" + immatriculation);
   }

   addVoiture(product:CreateVoitureDto):Observable<string> {
      return this.httpClient.post<string>(apiurl+"voitures/",product);
   }
}
