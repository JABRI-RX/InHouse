export interface FilterVoitureDto {
   marqueId?: string;
   modele?: string;
   annee?: string;
   couleurId?:string,
   importe?:boolean,
   immatriculation?: string,
   accessories?:string[]
   transmission?:string[]
   clientCIN?: string;
}
