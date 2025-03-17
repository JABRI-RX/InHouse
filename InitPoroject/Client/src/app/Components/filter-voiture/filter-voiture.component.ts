import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {InputText} from 'primeng/inputtext';
import {Button} from 'primeng/button';
import {Divider} from 'primeng/divider';
import {Select} from 'primeng/select';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from '@angular/forms';
import {SelectOBj} from '../../Helpers/SelectOBj';
import {commonCarBrands} from '../../Helpers/VoitureMarque';
import {commonYears} from '../../Helpers/Annee';
import {FilterVoitureDto} from '../../Models/FilterVoitureDto';
import {SelectButton} from 'primeng/selectbutton';

// @ts-ignore
@Component({
   selector: 'app-filter-voiture',
   imports: [
      InputText,
      Button,
      Divider,
      Select,
      FormsModule,
      ReactiveFormsModule,
      SelectButton
   ],
   templateUrl: './filter-voiture.component.html',
   styles: ``
})
export class FilterVoitureComponent implements OnInit {
   @Output() filterVoitureEvent = new EventEmitter<FilterVoitureDto>();
   @Output() resetFilterEvent = new EventEmitter();
   @Input() couleurs: SelectOBj[] = [];
   @Input() marques: SelectOBj[] = [];
   filterVoitured: FilterVoitureDto | undefined;
   annees: SelectOBj[] | undefined;
   importeOptions = [
      {label:"Oui",value:true},
      {label:"Non",value:false},
   ]
   filterVoitureForm = new FormGroup({
      marque: new FormControl("", {nonNullable: true}),
      couleur: new FormControl("", {nonNullable: true}),
      importe:new FormControl(undefined,{nonNullable:true}),
      annee: new FormControl("", {nonNullable: true}),
      immatriculation: new FormControl("", {nonNullable: true}),
      modele: new FormControl("", {nonNullable: true}),
      clientCIN: new FormControl("", {nonNullable: true}),
   });

   ngOnInit(): void {
      // this.marques = commonCarBrands;
      // this.couleurs = [];
      this.annees = commonYears(40);
   }

   filterVoiture() {
      //
      this.filterVoitured = {
         marqueId:(this.filterVoitureForm.value.marque as unknown as SelectOBj).code ??"",
         couleurId:(this.filterVoitureForm.value.couleur as unknown as SelectOBj).code ??"",
         importe:this.filterVoitureForm.value.importe!,
         annee:(this.filterVoitureForm.value.annee as unknown as SelectOBj).code ??"",
         immatriculation:this.filterVoitureForm.value.immatriculation!,
         modele:this.filterVoitureForm.value.modele!,
         clientCIN:this.filterVoitureForm.value.clientCIN!,
      }
      console.log(this.filterVoitured);
      this.filterVoitureEvent.emit(this.filterVoitured);

   }

   resetFilter() {

      this.filterVoitureForm.reset();
      this.resetFilterEvent.emit();
   }
}
