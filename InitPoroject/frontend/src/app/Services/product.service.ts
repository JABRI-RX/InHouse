import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateProductDto} from "../Models/CreateProductDto";
import {ReadProductDto} from "../Models/ReadProduct";
import { Observable } from 'rxjs';
import {apiurl} from "../Config/APICONFIG";
import {QueryObject} from "../Helpers/QueryObject";
@Injectable({
   providedIn: 'root'
})
export class ProductService {
   constructor(private httpClient: HttpClient) {
   }
   getAllProducts(query:QueryObject) :Observable<ReadProductDto[]>{
      const queryParms = ``;
      return this.httpClient.get<ReadProductDto[]>(apiurl+"products");
   }
   addProduct(product:CreateProductDto):Observable<ReadProductDto>{
      return this.httpClient.post<ReadProductDto>(apiurl+"products",product);
   }
   getProductById(product:CreateProductDto):Observable<ReadProductDto>{
      return this.httpClient.post<ReadProductDto>(apiurl+"products",product);
   }
}
