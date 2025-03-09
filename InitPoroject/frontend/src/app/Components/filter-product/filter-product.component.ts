import {Component, EventEmitter, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ReadProductDto} from "../../Models/ReadProduct";
import {QueryObject} from "../../Helpers/QueryObject";

@Component({
  selector: 'app-filter-product',
  templateUrl: './filter-product.component.html',
  styleUrl: './filter-product.component.css'
})
export class FilterProductComponent {

   @Output() filterProductsEvent = new EventEmitter<QueryObject>();
   filterProductForm = new FormGroup({
      name:new FormControl("",[Validators.required]),
      price:new FormControl("",[Validators.required]),
      quantity:new FormControl("",[Validators.required]),
      category:new FormControl("",[Validators.required]),
   })
   filterProducts(){
      this.filterProductsEvent.emit({
         name:this.filterProductForm.value.name!,
         category:this.filterProductForm.value.category!
      })
   }

}
