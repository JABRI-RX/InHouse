import {Component, Input, OnInit, signal} from '@angular/core';
import {ReadProductDto} from "../../Models/ReadProduct";
import {Colors} from "../../Helpers/ColorsArray";
import {CreateProductDto} from "../../Models/CreateProductDto";
import {ProductService} from "../../Services/product.service";
import {LoadingState} from "../../Helpers/loadingState";
import {QueryObject} from "../../Helpers/QueryObject";

@Component({
   selector: 'app-table',
   templateUrl: './table.component.html',
   styleUrl: './table.component.css'
})
export class TableComponent implements OnInit {

   @Input() products: ReadProductDto[] = [];
   showMaxNumberOfProducts = false;
   addProductState: boolean = true;
   state = signal<LoadingState>({
      text: "",
      stat: false,
      type: ""
   });
   options = Colors;
   selected: string[] = [];

   constructor(private productService: ProductService) {
      // this.state.set({});
   }

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

   ngOnInit(): void {
      this.state.set({
         text: "",
         stat: true,
         type: ""
      });
      this.showAllProducts(false);
   }
   maxNumberOfRows = 3;
   showAllProducts(showAll : boolean) {
      this.productService.getAllProducts({})
         .subscribe({
            next: (value) => {
               this.products = value.slice(0, showAll ? value.length : 3);
               console.log(showAll);
               this.state.set({
                  text: "",
                  stat: false,
                  type: ""
               });
            },
            error: (error) => {
               console.log(error);
               // this.state.stat = true;
            }
         })
   }

   filterProducts(query:QueryObject) {
      console.log(query);
   }
   addProduct(product: CreateProductDto) {
      this.productService.addProduct(product).subscribe({
         next:(value)=>{

         },
         error:(error)=>{

         }
      })
   }

   EditProduct(id: number) {

   }
   deleteProduct(product: ReadProductDto) {
      console.log(product.id);
   }

   showModel(id: string) {
      (document.getElementById(id) as HTMLDialogElement).showModal();
   }


}
