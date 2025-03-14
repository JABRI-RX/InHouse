import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TableModule} from 'primeng/table';
import {ReadVoitureDto} from '../../Models/ReadVoitureDto';

import { ConsulterVoitureModalComponent} from '../consulter-modal/consulter-voiture-modal.component';
import {ModifierVoitureModalComponent} from '../modifier-modal/modifier-voiture-modal.component';
import {SupprimerVoitureModalComponent} from '../supprimer-modal/supprimer-modal.component';
import {AjouterVoitureComponent} from '../ajouter-voiture/ajouter-voiture.component';
import {ProgressSpinner} from 'primeng/progressspinner';
import {Button} from 'primeng/button';
import {UpdateVoitureDto} from '../../Models/UpdateVoitureDto';
import {SelectOBj} from '../../Helpers/SelectOBj';

@Component({
  selector: 'app-lister-voiture',
   imports: [
      TableModule,
      ModifierVoitureModalComponent,
      SupprimerVoitureModalComponent,
      ConsulterVoitureModalComponent,
      ProgressSpinner,
      Button,

   ],
  templateUrl: './lister-voiture.component.html',
  styles: ``
})
export class ListerVoitureComponent implements OnInit{
   @Input() voitures: ReadVoitureDto[]  = [];
   @Input() couleurs:SelectOBj[] = [];
   @Input() loadingTable: boolean = false;
   @Output() deleteVoitureEvent = new EventEmitter<string>();
   @Output() editVoitureEvent = new EventEmitter<UpdateVoitureDto>();
   @Output() showAllVoituresEvent = new EventEmitter<boolean>();
   ngOnInit(): void {

   }
   showAllVoiture(showAll:boolean){

   }
   deleteVoiture(immatriculation: string) {
      this.deleteVoitureEvent.emit(immatriculation);
   }

   editVoiture(updateVoitureDto: UpdateVoitureDto) {
      this.editVoitureEvent.emit(updateVoitureDto);
   }
}
