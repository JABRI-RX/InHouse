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

// @ts-ignore
@Component({
   selector: 'app-filter-voiture',
   imports: [
      InputText,
      Button,
      Divider,
      Select,
      FormsModule,
      ReactiveFormsModule
   ],
   templateUrl: './filter-voiture.component.html',
   styles: ``
})
export class FilterVoitureComponent implements OnInit {
   @Input() couleurs:SelectOBj[] = [];
   @Output() filterVoitureEvent = new EventEmitter<FilterVoitureDto>();
   @Output() resetFilterEvent = new EventEmitter();
   filterVoitured:FilterVoitureDto | undefined;
   marques: SelectOBj[] | undefined;
   annees: SelectOBj[] | undefined;
   filterVoitureForm = new FormGroup({
      marque: new FormControl(""),
      couleur: new FormControl(""),
      annee: new FormControl(""),
      immatriculation: new FormControl(""),
      modele: new FormControl(""),
      clientCIN: new FormControl(""),
   });

   ngOnInit(): void {
      this.marques = commonCarBrands;
      this.couleurs = [];
      this.annees = commonYears(40);
   }

   filterVoiture() {

      this.filterVoitured = {
         marque:this.filterVoitureForm.value.marque!,
         couleurId:Number((this.filterVoitureForm.value.couleur as unknown as SelectOBj).code),
         annee:this.filterVoitureForm.value.annee!,
         immatriculation:this.filterVoitureForm.value.immatriculation!,
         clientCIN:this.filterVoitureForm.value.clientCIN!,
      }
      // console.log(this.filterVoitured);
      this.filterVoitureEvent.emit(this.filterVoitured);
   }

   resetFilter() {

      this.filterVoitureForm.reset();
      this.resetFilterEvent.emit();
   }
}
