import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Button} from "primeng/button";
import {Divider} from "primeng/divider";
import {InputText} from "primeng/inputtext";
import {KeyFilter} from 'primeng/keyfilter';
import {CreateVoitureDto} from '../../Models/CreateVoitureDto';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {Select} from 'primeng/select';
import {commonCarColors} from '../../Helpers/Colors';
import { commonCarBrands} from '../../Helpers/VoitureMarque';
import {NgIf} from '@angular/common';
import {SelectOBj} from '../../Helpers/SelectOBj';
import {commonYears} from '../../Helpers/Annee';
import {Textarea} from 'primeng/textarea';

@Component({
   selector: 'app-ajouter-voiture',
   imports: [
      Button,
      Divider,
      InputText,
      KeyFilter,
      ReactiveFormsModule,
      Select,
      FormsModule,
      NgIf,
      Textarea
   ],
   templateUrl: './ajouter-voiture.component.html',
   styles: ``
})
export class AjouterVoitureComponent implements OnInit {
   voiture:CreateVoitureDto | undefined;
   @Output() addVoitureEvent = new EventEmitter<CreateVoitureDto>();
   @Input() showForm: boolean = false;
   addVoitureForm = new FormGroup({
      marque: new FormControl("", [Validators.required]),
      modele: new FormControl("", [Validators.required]),
      annee: new FormControl("", [Validators.required]),
      couleur: new FormControl("", [Validators.required]),
      immatriculation: new FormControl("", [Validators.required]),
      clientCIN: new FormControl("", [Validators.required]),
   })
   get modele() {return this.addVoitureForm.get("modele")}
   get annee() {return this.addVoitureForm.get("annee")}
   get immatriculation() {return this.addVoitureForm.get("immatriculation")}
   get clientCIN() {return this.addVoitureForm.get("clientCIN")}

   colors: SelectOBj[] | undefined;
   selectedColor: SelectOBj | undefined;
   marques: SelectOBj[] | undefined;
   selectedMarque: SelectOBj | undefined;
   years: SelectOBj[] | undefined;
   selectedYear: SelectOBj | undefined;
   // years

   ngOnInit() {
      this.colors = commonCarColors;
      this.marques = commonCarBrands;
      this.years = commonYears(50);
   }

   addVoiture() {

      if( this.selectedColor === undefined || this.selectedMarque === undefined)
      {
         console.log("Populate the selects");
         return;
      }
      this.addVoitureForm.patchValue({
         marque: this.selectedMarque?.code  ??"NOTHING",
         couleur: this.selectedColor?.code ?? "NOTHING",
         annee: this.selectedYear?.code ?? "0000"
      })
      if(this.addVoitureForm.invalid )
      {
         console.log("Form is Invalid");
         return;
      }
      this.voiture = {
         immatriculation:this.addVoitureForm.value.immatriculation!,
         annee: Number(this.addVoitureForm.value.annee!),
         couleur:this.addVoitureForm.value.couleur!,
         modele:this.addVoitureForm.value.modele!,
         marque:this.addVoitureForm.value.marque!,
         clientCIN:this.addVoitureForm.value.clientCIN!,
      }
      this.addVoitureEvent.emit(this.voiture)

   }

}
