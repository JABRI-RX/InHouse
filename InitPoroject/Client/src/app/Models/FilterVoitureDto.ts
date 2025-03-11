export interface FilterVoitureDto {
   marque?: string;
   modele?: string;
   annee?: string;
   couleur?: string;
   immatriculation?: string;
   accessories?:string[]
   transmission?:string[]
   clientCIN?: string;
}
