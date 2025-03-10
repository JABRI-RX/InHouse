import { Routes } from '@angular/router';
import {HomeComponent} from './Pages/home/home.component';
import {GestionVoituresComponent} from './Pages/gestion-voitures/gestion-voitures.component';
import {GestionClientsComponent} from './Pages/gestion-clients/gestion-clients.component';
import {ContactComponent} from './Pages/contact/contact.component';

export const routes: Routes = [
   {
      path:"",
      component:HomeComponent,
   },
   {
      path:"gestionVoitures",
      component:GestionVoituresComponent
   },
   {
      path:"gestionclients",
      component:GestionClientsComponent
   },
   {
      path:"contact",
      component:ContactComponent
   }
];
