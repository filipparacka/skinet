import { Component, Input } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { Product } from '../../shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent {
  @Input() product?: Product;

  constructor(private basketService: BasketService) { }

  addItemToBasket() {
    this.product && this.basketService.addItemToBasket(this.product);
  }
}
