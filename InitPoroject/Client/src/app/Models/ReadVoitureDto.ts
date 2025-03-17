export interface ReadVoitureDto {
   marque: string;
   marqueId:number,
   modele: string;
   annee: number;
   couleur: string;
   couleurId:number,
   importe:boolean,
   immatriculation: string,
   accessories:string[],
   transmission:string[],
   clientCIN: string;
}
