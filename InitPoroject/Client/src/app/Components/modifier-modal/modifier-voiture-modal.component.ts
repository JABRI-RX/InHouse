import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Button} from 'primeng/button';
import {Dialog} from 'primeng/dialog';
import {InputText} from 'primeng/inputtext';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {KeyFilter} from 'primeng/keyfilter';
import {NgIf} from '@angular/common';
import {SelectOBj} from '../../Helpers/SelectOBj';
import {ReadVoitureDto} from '../../Models/ReadVoitureDto';
import {commonCarBrands} from '../../Helpers/VoitureMarque';
import {commonAccessories} from '../../Helpers/AccessoriesData';
import {commonCarColors} from '../../Helpers/Colors';
import {commonYears} from '../../Helpers/Annee';
import {Select} from 'primeng/select';
import {MultiSelect} from 'primeng/multiselect';
import {commonTransmissions} from '../../Helpers/TransmissionData';
import {UpdateVoitureDto} from '../../Models/UpdateVoitureDto';
import {endWith} from 'rxjs';

@Component({
   selector: 'app-modifier-voiture-modal',
   imports: [
      Button,
      Dialog,
      InputText,
      FormsModule,
      NgIf,
      ReactiveFormsModule,
      KeyFilter,
      Select,
      MultiSelect
   ],
   templateUrl: './modifier-voiture-modal.component.html',
   styles: ``
})
export class ModifierVoitureModalComponent implements OnInit {

   @Input() voiture: ReadVoitureDto | undefined;
   @Output() editVoitureEvent = new EventEmitter<UpdateVoitureDto>();
   editVoitureForm!: FormGroup;

   visible: boolean = false;
   colorsList: SelectOBj[] = [];
   marquesList: SelectOBj[] = [];
   yearsList: SelectOBj[] = [];
   // years
   //this list is used for listing all accessories to populate the whole listing
   accessoriesList: SelectOBj[] = [];
   //this list is used for listing all accessories that are selected already in the Input voiture
   selectedVoitureAccessoriesList: SelectOBj[] = [];

   //this list is used for listing all Transmission to populate the whole listing
   transmissionsList: SelectOBj[] = [];
   //this list is used for listing all Transmission that are selected already
   selectedVoitureTransmissionsList: SelectOBj[] = [];

   ngOnInit(): void {

      this.marquesList = commonCarBrands;
      this.accessoriesList = commonAccessories;
      this.transmissionsList = commonTransmissions;
      this.colorsList = commonCarColors;
      this.yearsList = commonYears(30);
      //populate the selectedAcc
      const mapSelectedAccessories = (accessories: string[]): SelectOBj[] => {
         return accessories.map(acc => ({name: acc, code: acc})) ?? [];
      }
      this.selectedVoitureAccessoriesList = mapSelectedAccessories(this.voiture?.accessories!);
      const mapSelectedTransmission = (transmission: string[]): SelectOBj[] => {
         return transmission.map(trans => ({name: trans, code: trans})) ?? [];
      } ;
      this.selectedVoitureTransmissionsList = mapSelectedTransmission(this.voiture?.transmission!);

      //we use the selectObj to map the data from the voiture
      this.editVoitureForm = new FormGroup({
         marque: new FormControl<SelectOBj>(
            {name: `${this.voiture?.marque}`, code: `${this.voiture?.marque}`},
            [Validators.required]
         ),
         modele: new FormControl(this.voiture?.modele, [Validators.required]),
         annee: new FormControl<SelectOBj>(
            {name: `${this.voiture?.annee}`, code: `${this.voiture?.annee}`},
            [Validators.required]
         ),
         couleur: new FormControl<SelectOBj>(
            {name: `${this.voiture?.couleur}`, code: `${this.voiture?.couleur}`},
            [Validators.required]
         ),
         accessories: new FormControl<SelectOBj[]>(
            this.selectedVoitureAccessoriesList,
            [Validators.required]
         ),
         transmissions: new FormControl<SelectOBj[]>(
            this.selectedVoitureTransmissionsList,
            [Validators.required]
         ),
         clientCIN: new FormControl(this.voiture?.clientCIN, [Validators.required]),
      });
   }
   get modele() {return this.editVoitureForm?.get("modele");}
   get accessories() {return this.editVoitureForm?.get("accessories");}
   get transmissions() {return this.editVoitureForm?.get("transmissions");}
   get clientCIN() {return this.editVoitureForm?.get("clientCIN");}
   showDialog() {this.visible = true;}
   editVoiture() {
      const updateVoitureDto:UpdateVoitureDto = {
         immatriculation :this.voiture?.immatriculation!,
         marque:(this.editVoitureForm.value.marque as SelectOBj).code,
         modele:this.modele?.value,
         annee:this.editVoitureForm.value.annee.code,
         couleur:this.editVoitureForm.value.couleur.code,
         accessories:(this.accessories?.value as SelectOBj[]).map(acc=>acc.code),
         transmission:(this.transmissions?.value as SelectOBj[]).map(trans=>trans.code),
         clientCIN:this.clientCIN?.value,
      }
      this.editVoitureEvent.emit(updateVoitureDto);
   }
}
