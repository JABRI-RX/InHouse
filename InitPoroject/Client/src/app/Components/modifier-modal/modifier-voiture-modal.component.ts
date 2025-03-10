import { Component } from '@angular/core';
import {Button} from 'primeng/button';
import {Dialog} from 'primeng/dialog';
import {InputText} from 'primeng/inputtext';

@Component({
  selector: 'app-modifier-voiture-modal',
   imports: [
      Button,
      Dialog,
      InputText
   ],
  templateUrl: './modifier-voiture-modal.component.html',
  styles: ``
})
export class ModifierVoitureModalComponent {
   visible: boolean = false;

   showDialog() {
      this.visible = true;
   }
}
