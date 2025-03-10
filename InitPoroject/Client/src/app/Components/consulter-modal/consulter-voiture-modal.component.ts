import {Component, Input} from '@angular/core';
import {ReadVoitureDto} from '../../Models/ReadVoitureDto';
import {Button} from 'primeng/button';
import {Dialog} from 'primeng/dialog';
import {Card} from 'primeng/card';

@Component({
   selector: 'app-consulter-voiture-modal',
   imports: [
      Button,
      Dialog,
      Card
   ],
   templateUrl: './consulter-voiture-modal.component.html',
})
export class ConsulterVoitureModalComponent {
   @Input() voiture: ReadVoitureDto | undefined;
   visible: boolean = false;

   showDialog() {
      this.visible = true;
   }
}
