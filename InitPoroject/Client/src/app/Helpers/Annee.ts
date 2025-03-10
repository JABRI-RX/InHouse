import {SelectOBj} from './SelectOBj';

export const commonYears = (length:number)=>{
   let years :SelectOBj[] = [];
   const currentYear = new Date().getFullYear();
   for (let i = 0; i < length ; i++) {
      years.push({name: String(currentYear - i),code:String(currentYear - i)})
   }
   return years;
}
