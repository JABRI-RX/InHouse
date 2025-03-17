import {SelectOBj} from './SelectOBj';
import {ReadCouleur} from '../Models/Couleur/ReadCouleur';
import {ReadMarque} from '../Models/Marque/ReadMarque';
export const FromReadCouleurToSelectObj = (readcolors:ReadCouleur[]):SelectOBj[]=>{
   const colorsSelectResult:SelectOBj[] = [];
   for (const color of readcolors) {
      colorsSelectResult.push({name:color.nomCouleur,code:color.couleurId.toString()});
   }
   return colorsSelectResult;
}

export const FromReadMarqueToSelectObj = (readmarques:ReadMarque[]):SelectOBj[]=>{
   const marquesSelectResult:SelectOBj[] = [];
   for (const marque of readmarques) {
      marquesSelectResult.push({name:marque.nomMarque,code:marque.marqueId.toString()});
   }
   return marquesSelectResult;
}
