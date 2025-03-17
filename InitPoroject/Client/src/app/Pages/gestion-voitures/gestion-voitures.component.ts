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
import {FromReadCouleurToSelectObj, FromReadMarqueToSelectObj} from '../../Helpers/ConvertFunctions';
import {MarqueService} from '../../Services/marque.service';

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
   providers: [MessageService]

})
export class GestionVoituresComponent implements OnInit {
   voitures: ReadVoitureDto[] = [];
   filterVoituresQuery: FilterVoitureDto | undefined;
   //this couleurs used to pass the data to  the children that need it (filter ,modifier ,ajouter)
   colors: SelectOBj[] = [];
   //this marques used to pass the data to  the children that need it (filter ,modifier ,ajouter)
   marques: SelectOBj[] = [];
   showForm: boolean = true;
   loadingTable: boolean = false;

   constructor(private voitureService: VoitureService,
               private couleurService: CouleurService,
               private marqueService:MarqueService,
               private messageService: MessageService) {
   }

   ngOnInit(): void {
      //init colors
      this.couleurService.getAllCouleurs().subscribe({
         next: (values) => this.colors = FromReadCouleurToSelectObj(values)
      });
      this.marqueService.getAllMarques().subscribe({
         next:(values) =>this.marques = FromReadMarqueToSelectObj(values)
      });
      this.populateVoiture(false);
   }

   filterVoiture(voiture: FilterVoitureDto) {
      this.filterVoituresQuery = voiture;
      this.populateVoiture(true);
      this.filterVoituresQuery = {}
   }

   addVoiture(voiture: CreateVoitureDto) {
      console.log(voiture);
      this.voitureService.addVoiture(voiture).subscribe({
         next: (value) => {
            this.voitures.push(value);
            this.messageService.add({severity: 'success', summary: 'Stat', detail: "Voiture Cree", life: 3000});
         },
         error: (error: HttpErrorResponse) => {
            this.messageService.add({severity: 'error', summary: 'Stat', detail: error.error.message, life: 3000});
         }
      });
   }

   populateVoiture(filterSearchState: boolean) {
      this.loadingTable = true;
      this.voitureService.getAllVoitures(filterSearchState ? this.filterVoituresQuery : undefined)
         .subscribe({
            next: (value) => {
               this.voitures = value;

               this.loadingTable = false;
            },
            error: (error) => {
               console.log("To Be Implmented")
               console.log(error)
            }
         })
   }

   editVoiture(updateVoitureDto: UpdateVoitureDto) {
      this.voitureService.updateVoiture(updateVoitureDto)
         .subscribe({
            next: (readDto) => {
               const updateVoitureIndex = this.voitures.findIndex(v => v.immatriculation === updateVoitureDto.immatriculation);
               this.voitures[updateVoitureIndex].marque = readDto.marque;
               this.voitures[updateVoitureIndex].annee = readDto.annee;
               this.voitures[updateVoitureIndex].importe = readDto.importe;
               this.voitures[updateVoitureIndex].couleur = readDto.couleur;
               this.voitures[updateVoitureIndex].modele = readDto.modele;
               this.voitures[updateVoitureIndex].accessories = readDto.accessories;
               this.voitures[updateVoitureIndex].transmission = readDto.transmission;
               // this.voitures[updateVoitureIndex] = {
               //    marque:readDto.marque,
               //    annee:updateVoitureDto.annee,
               //    importe:updateVoitureDto.importe,
               // }
               this.messageService.add({severity: 'success', summary: 'Stat', detail: "Voiture Modifier", life: 3000});
            },
            error: (error: HttpErrorResponse) => {
               this.messageService.add({severity: 'error', summary: 'Stat', detail: error.error.message, life: 3000});
            }
         })
   }

   deleteVoiture(immatriculation: string) {
      this.voitureService.deleteVoiture(immatriculation)
         .subscribe({
            next: (value) => {
               this.messageService.add({severity: 'success', summary: 'Stat', detail: "Voiture Supprimer", life: 3000});
               const deleteVoitureIndex = this.voitures.findIndex(v=>v.immatriculation === immatriculation);
               this.voitures = this.voitures.splice(deleteVoitureIndex,1);
            },
            error: (error: HttpErrorResponse) => {

            }
         })
   }

   resetFilter() {
      console.log("Filter Clicked");
      this.populateVoiture(false);
   }


}
