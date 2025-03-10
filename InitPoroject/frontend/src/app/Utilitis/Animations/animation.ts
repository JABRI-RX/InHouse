import {animate, style, transition, trigger} from "@angular/animations";

export const fadeInAnimation =
   trigger('fadeIn', [
      transition(':leave', [
         style({opacity: 1}),
         animate('500ms',style({opacity:0}))
      ])
   ]);
