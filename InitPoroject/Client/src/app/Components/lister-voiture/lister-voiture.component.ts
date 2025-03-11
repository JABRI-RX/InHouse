import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TableModule} from 'primeng/table';
import {ReadVoitureDto} from '../../Models/ReadVoitureDto';

import { ConsulterVoitureModalComponent} from '../consulter-modal/consulter-voiture-modal.component';
import {ModifierVoitureModalComponent} from '../modifier-modal/modifier-voiture-modal.component';
import {SupprimerVoitureModalComponent} from '../supprimer-modal/supprimer-modal.component';
import {AjouterVoitureComponent} from '../ajouter-voiture/ajouter-voiture.component';
import {ProgressSpinner} from 'primeng/progressspinner';

@Component({
  selector: 'app-lister-voiture',
   imports: [
      TableModule,
      ModifierVoitureModalComponent,
      SupprimerVoitureModalComponent,
      ConsulterVoitureModalComponent,
      AjouterVoitureComponent,
      ProgressSpinner,

   ],
  templateUrl: './lister-voiture.component.html',
  styles: ``
})
export class ListerVoitureComponent implements OnInit{
   @Input() voitures: ReadVoitureDto[]  = [];
   @Output() deleteVoitureEvent = new EventEmitter<string>();
   @Input() loadingTable: boolean = false;
   ngOnInit(): void {

   }

   deleteVoiture(immatriculation: string) {
      this.deleteVoitureEvent.emit(immatriculation);
   }
}
