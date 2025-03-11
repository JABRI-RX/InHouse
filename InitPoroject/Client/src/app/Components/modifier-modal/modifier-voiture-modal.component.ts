import {Component, Input, OnInit} from '@angular/core';
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
      Select
   ],
   templateUrl: './modifier-voiture-modal.component.html',
   styles: ``
})
export class ModifierVoitureModalComponent implements OnInit {

   @Input() voiture: ReadVoitureDto | undefined;
   editVoitureForm!: FormGroup;

   ngOnInit(): void {
      this.marquesList = commonCarBrands;
      this.accessoriesList = commonAccessories;
      this.colorsList = commonCarColors;
      this.yearsList = commonYears(30);
      this.editVoitureForm = new FormGroup({
         marque: new FormControl<SelectOBj>(
            {name: `${this.voiture?.marque}`, code:`${this.voiture?.marque}`},
            [Validators.required]
         ),
         modele: new FormControl(this.voiture?.modele, [Validators.required]),
         annee: new FormControl<SelectOBj>(
            {name: `${this.voiture?.annee}`, code:`${this.voiture?.annee}`},
            [Validators.required]
         ),
         couleur: new FormControl<SelectOBj>(
            {name: `${this.voiture?.couleur}`, code:`${this.voiture?.couleur}`},
            [Validators.required]
         ),
         accessories: new FormControl<SelectOBj[]>(
            [],
            [Validators.required]
         ),
         transmissions: new FormControl<SelectOBj[]>(
            [],
            [Validators.required]
         ),
         clientCIN: new FormControl(this.voiture?.clientCIN, [Validators.required]),
      })
   }

   get marque() {
      return this.editVoitureForm?.get("marque");
   }

   get modele() {
      return this.editVoitureForm?.get("marque");
   }

   get annee() {
      return this.editVoitureForm?.get("annee");
   }

   get accessories() {
      return this.editVoitureForm?.get("accessories");
   }

   get transmissions() {
      return this.editVoitureForm?.get("transmissions");
   }

   get clientCIN() {
      return this.editVoitureForm?.get("clientCIN");
   }

   visible: boolean = false;
   colorsList: SelectOBj[] = [];
   marquesList: SelectOBj[] = [];
   yearsList: SelectOBj[] = [];
   // years
   accessoriesList: SelectOBj[] = [];
   transmissionList: SelectOBj[] = [];

   showDialog() {
      this.visible = true;
   }
}
