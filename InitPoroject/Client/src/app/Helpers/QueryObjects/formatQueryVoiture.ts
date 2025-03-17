import {FilterVoitureDto} from '../../Models/FilterVoitureDto';

export const formatFilterQueryVoiture = (filterVoiture: FilterVoitureDto ):string=>{
   if(!filterVoiture)
      return "";
   const queryParams:string[] = [];
   for(const [key,value] of Object.entries(filterVoiture))
      if(value !== undefined && value !== null && value !== "")
         queryParams.push(`${key}=${encodeURIComponent(value)}`)
   return queryParams.join("&");
}
