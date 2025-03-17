export interface UpdateVoitureDto {
   immatriculation: string;
   marqueId: string;
   modele: string;
   annee: number;
   importe:boolean,
   couleurId: string;
   accessories:string[]
   transmission:string[]
   clientCIN: string;
}
