export interface ReadVoitureDto {
   id: number;
   marque: string;
   modele: string;
   annee: number;
   couleur: string;
   immatriculation: string;
   accessories:string[]
   transmission:string[]
   clientCIN: string;
}
