import {Component, OnInit} from '@angular/core';
import {FilterVoitureComponent} from '../../Components/filter-voiture/filter-voiture.component';
import {Divider} from 'primeng/divider';
import {ListerVoitureComponent} from '../../Components/lister-voiture/lister-voiture.component';
import {AjouterVoitureComponent} from '../../Components/ajouter-voiture/ajouter-voiture.component';
import {CreateVoitureDto} from '../../Models/CreateVoitureDto';
import {VoitureService} from '../../Services/voiture.service';
import {ReadVoitureDto} from '../../Models/ReadVoitureDto';
import {Toast} from 'primeng/toast';
import {HttpErrorResponse} from '@angular/common/http';
import {MessageService} from 'primeng/api';
import {Button} from 'primeng/button';
import {FilterVoitureDto} from '../../Models/FilterVoitureDto';
import {FormsModule} from '@angular/forms';
import {UpdateVoitureDto} from '../../Models/UpdateVoitureDto';
import {SelectOBj} from '../../Helpers/SelectOBj';
import {ReadCouleur} from '../../Models/Couleur/ReadCouleur';
import {CouleurService} from '../../Services/couleur.service';
import {FromReadCouleurToSelectObj} from '../../Helpers/ColorsFunctions';

@Component({
  selector: 'app-gestion-voitures',
   imports: [
      FilterVoitureComponent,
      Divider,
      ListerVoitureComponent,
      AjouterVoitureComponent,
      Toast,
      Button,
      FormsModule
   ],
  templateUrl: './gestion-voitures.component.html',
  styles: ``,
   providers:[MessageService]

})
export class GestionVoituresComponent implements OnInit{
   voitures :ReadVoitureDto[] = [];
   filterVoituresQuery:FilterVoitureDto| undefined;
   //this couleurs used to pass the data to the the children that need it
   colors:SelectOBj[] = [];
   showForm:boolean = true;
   loadingTable: boolean = false;
   constructor(private voitureService:VoitureService,
               protected couleurService:CouleurService,
               private messageService : MessageService) {
   }

   ngOnInit(): void {
      //init colors
      this.couleurService.getAllCouleurs().subscribe({
         next:(values)=>this.colors = FromReadCouleurToSelectObj(values)
      })

      this.populateVoiture(false);
   }
   filterVoiture(voiture:FilterVoitureDto){
      this.filterVoituresQuery = voiture;
      this.populateVoiture(true);
      this.filterVoituresQuery = {}
   }
   addVoiture(voiture:CreateVoitureDto){
      console.log(voiture);
      this.voitureService.addVoiture(voiture).subscribe({
         next:(value)=>{
            this.populateVoiture(false);
            this.messageService.add({ severity: 'success', summary: 'Stat', detail: "Voiture Cree", life: 3000 });
         },
         error:(error:HttpErrorResponse)=>{
            this.messageService.add({ severity: 'error', summary: 'Stat', detail: error.error.message, life: 3000 });
         }
      });
   }
   populateVoiture(filterSearchState:boolean){
      this.loadingTable = true;
      this.voitureService.getAllVoitures(filterSearchState ? this.filterVoituresQuery: undefined )
         .subscribe({
            next:(value)=>{
               this.voitures = value;
               this.loadingTable = false;
            },
            error:(error)=>{
               console.log("To Be Implmented")
               console.log(error)
            }
         })
   }
   editVoiture(updateVoitureDto: UpdateVoitureDto) {
      this.voitureService.updateVoiture(updateVoitureDto)
         .subscribe({
            next:(readDto)=> {
               const updateVoitureIndex = this.voitures.findIndex(v=>v.immatriculation === updateVoitureDto.immatriculation);
               this.voitures[updateVoitureIndex].marque = updateVoitureDto.marque;
               this.voitures[updateVoitureIndex].annee = updateVoitureDto.annee;
               this.voitures[updateVoitureIndex].couleur = readDto.couleur;
               this.voitures[updateVoitureIndex].modele = updateVoitureDto.modele;
               this.voitures[updateVoitureIndex].accessories = updateVoitureDto.accessories;
               this.voitures[updateVoitureIndex].transmission = updateVoitureDto.transmission;
               this.messageService.add({ severity: 'success', summary: 'Stat', detail: "Voiture Modifier", life: 3000 });
            },
            error:(error:HttpErrorResponse)=>{
               this.messageService.add({ severity: 'error', summary: 'Stat', detail: error.error.message, life: 3000 });
            }
         })
   }
   deleteVoiture(immatriculation:string){
      this.voitureService.deleteVoiture(immatriculation)
         .subscribe({
            next:(value)=>{
               this.messageService.add({ severity: 'success', summary: 'Stat', detail: "Voiture Supprimer", life: 3000 });

               this.populateVoiture(false);
            },
            error:(error:HttpErrorResponse)=>{

            }
         })
   }

   resetFilter() {
      console.log("Filter Clicked");
      this.populateVoiture(false);
   }


}
