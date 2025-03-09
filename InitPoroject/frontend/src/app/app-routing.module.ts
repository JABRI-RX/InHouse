import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomePageComponent} from "./Pages/home-page/home-page.component";
import {TablePageComponent} from "./Pages/table-page/table-page.component";

const routes: Routes = [

  {
    path:"",
    component:HomePageComponent,
  },
  {
    path:"products",
    component:TablePageComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
