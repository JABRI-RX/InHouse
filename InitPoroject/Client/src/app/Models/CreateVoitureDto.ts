export interface CreateVoitureDto {
   marque: string;
   modele: string;
   annee: number;
   couleurId: string;
   immatriculation: string;
   accessories:string[]
   transmission:string[]
   clientCIN: string;
}
