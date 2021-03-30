import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-restaurant-order',
  templateUrl: './restaurant-order.component.html',
  styleUrls: ['./restaurant-order.component.scss']
})
export class RestaurantOrderComponent implements OnInit {
  output: any;

  constructor() { }

  ngOnInit(): void {
  }

  getOrderOutput(output: any) {
    this.output = output;
  }

}
