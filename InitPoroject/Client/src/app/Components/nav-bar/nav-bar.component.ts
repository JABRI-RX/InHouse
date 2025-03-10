import {Component, OnInit} from '@angular/core';
import {Menubar} from 'primeng/menubar';
import {MenuItem} from 'primeng/api';
import {Button} from 'primeng/button';
import {NgClass} from '@angular/common';
import {Badge} from 'primeng/badge';
import {Avatar} from 'primeng/avatar';
import {RouterLink} from '@angular/router';
import ToggleDarkMode from '../../Helpers/darkmodeToggle';


@Component({
   selector: 'app-nav-bar',
   imports: [
      Menubar,
      RouterLink,
      Button,
   ],
   templateUrl: './nav-bar.component.html',
   styles: ``
})
export class NavBarComponent implements OnInit {
   items: MenuItem[] | undefined;

   ngOnInit(): void {

      this.items = [
         {
            label: 'Accueille',
            routerLink : "/",
            icon: 'pi pi-home'
         },
         {
            label: 'Gestion Voitures',
            routerLink:"gestionVoitures",
            icon: 'pi pi-car'
         },
         {
            label: 'Gestion Client',
            routerLink:"gestionclients",
            icon: 'pi pi-user',

         },
         {
            label: 'Contact',
            routerLink:"contact",
            icon: 'pi pi-envelope'
         }
      ];
   }

   protected readonly ToggleDarkMode = ToggleDarkMode;
}
