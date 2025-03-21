import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {Button} from "primeng/button";
import {Divider} from "primeng/divider";
import {InputText} from "primeng/inputtext";
import {KeyFilter} from 'primeng/keyfilter';
import {CreateVoitureDto} from '../../Models/CreateVoitureDto';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {Select} from 'primeng/select';
import {commonCarBrands} from '../../Helpers/VoitureMarque';
import {NgIf} from '@angular/common';
import {SelectOBj} from '../../Helpers/SelectOBj';
import {commonYears} from '../../Helpers/Annee';
import {Textarea} from 'primeng/textarea';
import {MultiSelect} from 'primeng/multiselect';
import {commonTransmissions} from '../../Helpers/TransmissionData';
import {commonAccessories} from '../../Helpers/AccessoriesData';
import {SelectButton} from 'primeng/selectbutton';

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
      MultiSelect,
      SelectButton,
   ],
   templateUrl: './ajouter-voiture.component.html',
   styles: ``
})
export class AjouterVoitureComponent implements OnInit {

   voiture:CreateVoitureDto | undefined;
   @Output() addVoitureEvent = new EventEmitter<CreateVoitureDto>();
   @Input() showForm: boolean = false;
   importeOptions = [
      {label:"Oui",value:true},
      {label:"Non",value:false},
   ]
   addVoitureForm = new FormGroup({
      marque: new FormControl<SelectOBj>({name:"",code:""}, [Validators.required]),
      modele: new FormControl("", [Validators.required]),
      annee: new FormControl<SelectOBj>({name:"",code:""}, [Validators.required]),
      importe:new FormControl(undefined,[Validators.required]),
      couleur: new FormControl<SelectOBj>({name:"",code:""}, [Validators.required]),
      immatriculation: new FormControl("", [Validators.required]),
      accessories: new FormControl<SelectOBj[]>([], [Validators.required]),
      transmissions: new FormControl<SelectOBj[]>([], [Validators.required]),
      clientCIN: new FormControl("", [Validators.required]),
   })
   get modele() {return this.addVoitureForm.get("modele")}
   get immatriculation() {return this.addVoitureForm.get("immatriculation")}

   get accessories() {return this.addVoitureForm.get("accessories")}
   get transmissions() {return this.addVoitureForm.get("transmissions")}

   get clientCIN() {return this.addVoitureForm.get("clientCIN")}

   @Input()  colors: SelectOBj[] = [];
   @Input() marques: SelectOBj[] = [];
   years: SelectOBj[] = [];
   // years
   accessoriesList: SelectOBj[] = [];
   transmissionList: SelectOBj[] = [];
   ngOnInit() {
      this.years = commonYears(50);
      this.transmissionList = commonTransmissions;
      this.accessoriesList = commonAccessories;
   }

   addVoiture() {

      if(this.addVoitureForm.invalid )
      {
         console.log("Form is Invalid");
         return;
      }
      this.voiture = {
         annee: Number(this.addVoitureForm.value.annee?.code),
         couleurId:this.addVoitureForm.value.couleur?.code!,
         modele:this.addVoitureForm.value.modele!,
         importe:this.addVoitureForm.value.importe!,
         marqueId:this.addVoitureForm.value.marque?.code!,
         immatriculation:this.addVoitureForm.value.immatriculation!,
         accessories:this.addVoitureForm.value.accessories?.map(a=>a.code)!,
         transmission:this.addVoitureForm.value.transmissions?.map(t=>t.code)!,
         clientCIN:this.addVoitureForm.value.clientCIN!,
      }
      // console.log(this.voiture);
      this.addVoitureEvent.emit(this.voiture)
   }
}
