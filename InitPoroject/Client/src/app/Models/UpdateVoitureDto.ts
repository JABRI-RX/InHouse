export interface UpdateVoitureDto {
   immatriculation: string;
   marque: string;
   modele: string;
   annee: number;
   couleurId: string;
   accessories:string[]
   transmission:string[]
   clientCIN: string;
}
