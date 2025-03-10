import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Button} from 'primeng/button';
import {Dialog} from 'primeng/dialog';
import {InputText} from 'primeng/inputtext';
import {ReadVoitureDto} from '../../Models/ReadVoitureDto';
import {Toast} from 'primeng/toast';
import {MessageService} from 'primeng/api';

@Component({
   selector: 'app-supprimer-voiture-modal',
   imports: [
      Button,
      Dialog,

      Toast
   ],
   templateUrl: './supprimer-voiture-modal.component.html',
})
export class SupprimerVoitureModalComponent {
   constructor( ) {
   }

   visible: boolean = false;
   @Input() voiture: ReadVoitureDto | undefined;
   @Output() deleteVoitureEvent = new EventEmitter<string>();

   deleteVoiture(immatriculation: string | undefined) {
      this.deleteVoitureEvent.emit(immatriculation);
      this.visible = false;
   }

   showDialog() {
      this.visible = true;
   }
}
