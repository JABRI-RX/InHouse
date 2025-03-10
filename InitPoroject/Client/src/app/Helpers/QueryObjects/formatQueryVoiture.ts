import {FilterVoitureDto} from '../../Models/FilterVoitureDto';

export const formatFilterQueryVoiture = (filterVoiture: FilterVoitureDto | undefined)=>{
   return `Marque=${filterVoiture?.marque ?? ""}&Couleur=${filterVoiture?.couleur ?? ""}&Annee=${filterVoiture?.annee ?? ""}&Immatriculation=${filterVoiture?.immatriculation ?? ""}&Modele=${filterVoiture?.modele ?? ""}&ClientCIN=${filterVoiture?.clientCIN ?? ""}`;
}
