export interface CreateVoitureDto {
   marqueId: string;
   modele: string;
   annee: number;
   importe:boolean,
   couleurId: string;
   immatriculation: string;
   accessories:string[]
   transmission:string[]
   clientCIN: string;
}
