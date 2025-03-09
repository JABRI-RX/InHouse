import {Component, Input, OnInit} from '@angular/core';
import {ReadProductDto} from "../../Models/ReadProduct";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit{
   ngOnInit(): void {
   }
   @Input() product:ReadProductDto| undefined;
}
