import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {DatePipe} from "@angular/common";
import {RouterOutlet} from "@angular/router";
import {NavBarComponent} from './Components/nav-bar/nav-bar.component';
import {HomePageComponent} from './Pages/home-page/home-page.component';
import {TableComponent} from './Components/table/table.component';
import {TablePageComponent} from './Pages/table-page/table-page.component';
import {ModalComponent} from './Components/modal/modal.component';
import {ProductDetailsComponent} from './Components/product-details/product-details.component';
import {AddProductComponent} from './Components/add-product/add-product.component';
import {ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {FilterProductComponent} from './Components/filter-product/filter-product.component';
import {provideAnimationsAsync} from "@angular/platform-browser/animations/async";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

@NgModule({
   declarations: [
      AppComponent,
      NavBarComponent,
      HomePageComponent,
      TableComponent,
      TablePageComponent,
      ModalComponent,
      ProductDetailsComponent,
      AddProductComponent,
      FilterProductComponent,


   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      AppRoutingModule,
      DatePipe,
      RouterOutlet,
      ReactiveFormsModule,
      HttpClientModule
   ],
   providers: [
      provideAnimationsAsync(),
   ],
   bootstrap: [AppComponent]
})
export class AppModule {
}
