import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ReadVoitureDto} from '../Models/ReadVoitureDto';
import {apiurl} from '../Config/APICONFIG';
import {CreateVoitureDto} from '../Models/CreateVoitureDto';
import {FilterVoitureDto} from '../Models/FilterVoitureDto';
import {formatFilterQueryVoiture} from '../Helpers/QueryObjects/formatQueryVoiture';
import {UpdateVoitureDto} from '../Models/UpdateVoitureDto';

@Injectable({
   providedIn: 'root'
})
export class VoitureService {
   constructor(private httpClient: HttpClient) {

   }

   addVoiture(product:CreateVoitureDto):Observable<string> {
      return this.httpClient.post<string>(apiurl+"voitures/",product);
   }

   getAllVoitures(filterVoitures: FilterVoitureDto | undefined): Observable<ReadVoitureDto[]> {
      let query = "";
      if(filterVoitures !== undefined)
         query  = formatFilterQueryVoiture(filterVoitures);
      return this.httpClient.get<ReadVoitureDto[]>(apiurl + "voitures?"+query);
   }
   updateVoiture( updateVoitureDto:UpdateVoitureDto):Observable<any>{

   }
   deleteVoiture(immatriculation: string): Observable<string> {
      return this.httpClient.delete<string>(apiurl + "voitures/" + immatriculation);
   }
}
