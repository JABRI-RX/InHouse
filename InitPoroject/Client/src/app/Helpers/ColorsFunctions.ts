import {SelectOBj} from './SelectOBj';
import {ReadCouleur} from '../Models/Couleur/ReadCouleur';
export const FromReadCouleurToSelectObj = (readcolors:ReadCouleur[]):SelectOBj[]=>{
   const colorsSelectResult:SelectOBj[] = [];
   for (const color of readcolors) {
      colorsSelectResult.push({name:color.nomCouleur,code:color.couleurId.toString()});
   }
   return colorsSelectResult;
}
// export const commonCarColors: SelectOBj[] = [
//    { name: "Noir", code: "Noir" },       // Black
//    { name: "Blanc", code: "Blanc" },     // White
//    { name: "Gris", code: "Gris" },       // Gray
//    { name: "Argent", code: "Argent" },   // Silver
//    { name: "Bleu", code: "Bleu" },       // Blue
//    { name: "Rouge", code: "Rouge" },     // Red
//    { name: "Vert", code: "Vert" },       // Green
//    { name: "Jaune", code: "Jaune" },     // Yellow
//    { name: "Orange", code: "Orange" },   // Orange
//    { name: "Marron", code: "Marron" },   // Brown
//    { name: "Beige", code: "Beige" },     // Beige
//    { name: "Rose", code: "Rose" },       // Pink
//    { name: "Violet", code: "Violet" },   // Purple
//    { name: "Or", code: "Or" },           // Gold
//    { name: "Bronze", code: "Bronze" },   // Bronze
//    { name: "Turquoise", code: "Turquoise" }, // Turquoise
//    { name: "Bordeaux", code: "Bordeaux" }, // Burgundy
//    { name: "Mauve", code: "Mauve" },     // Mauve
//    { name: "Corail", code: "Corail" },   // Coral
//    { name: "Indigo", code: "Indigo" }    // Indigo
// ];
