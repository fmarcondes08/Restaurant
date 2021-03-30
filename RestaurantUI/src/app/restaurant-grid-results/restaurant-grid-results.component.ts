import { Component, Input, OnChanges, OnInit, SimpleChange } from '@angular/core';
import { Order } from '../models/Order';

@Component({
  selector: 'app-restaurant-grid-results',
  templateUrl: './restaurant-grid-results.component.html',
  styleUrls: ['./restaurant-grid-results.component.scss']
})
export class RestaurantGridResultsComponent implements OnChanges {
  @Input('orderOutput') output: any;

  orderArray: Array<Order> = [];

  constructor() { }

  ngOnInit() {
    this.orderArray = [];
  }

  ngOnChanges(changes: {[propKey: string]: SimpleChange}) {
    for (let prop in changes) {
      if (prop === 'output') {
        if (changes[prop].currentValue !== undefined) {
          this.orderArray.unshift(changes[prop].currentValue);
        }
      }
    }
  }
}
