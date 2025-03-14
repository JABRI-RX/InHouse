export interface FilterVoitureDto {
   marque?: string;
   modele?: string;
   annee?: string;
   couleurId?:number
   immatriculation?: string;
   accessories?:string[]
   transmission?:string[]
   clientCIN?: string;
}
