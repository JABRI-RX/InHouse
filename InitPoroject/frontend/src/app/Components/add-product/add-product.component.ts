import {Component, EventEmitter, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Colors} from "../../Helpers/ColorsArray";
import {ReadProductDto} from "../../Models/ReadProduct";
import { CreateProductDto } from '../../Models/CreateProductDto';
@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {
   options = Colors;
   selected: string[] = [];
   @Output() addProductEvent = new EventEmitter<CreateProductDto>();
   product:CreateProductDto | undefined ;
   addProductForm = new FormGroup({
      name:new FormControl("Iphone 8",[Validators.required]),
      price:new FormControl(1000,[Validators.required]),
      quantity:new FormControl(10,[Validators.required]),
      colors:new FormControl([],[Validators.required]),
      category:new FormControl("Mobile Phone",[Validators.required]),
   })
   toggleSelect(option: string) {
      if (this.selected.includes(option)) {
         this.selected = this.selected.filter(item => item !== option);
      } else {
         this.selected.push(option);
      }
   }
   removeSelection(option: string) {
      this.selected = this.selected.filter(item => item !== option);
   }

   AddProduct() {
      this.addProductForm.value.colors = this.selected as never[];
      this.product = {
         name: this.addProductForm.value.name!,
         price: this.addProductForm.value.price!,
         quantity: this.addProductForm.value.quantity!,
         category: this.addProductForm.value.category!,
         colors: this.addProductForm.value.colors,
      }
      this.addProductEvent.emit(this.product)
   }
}
