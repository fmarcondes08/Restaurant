import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Order } from 'src/app/models/Order';
import { RestaurantOrderFormService } from './restaurant-order-form.service';

@Component({
  selector: 'app-restaurant-order-form',
  templateUrl: './restaurant-order-form.component.html',
  styleUrls: ['./restaurant-order-form.component.scss']
})
export class RestaurantOrderFormComponent implements OnInit {
  orderInput: string = '';
  orderOutput: string = '';
  order: Order | undefined;
  errorMessage: String = '';

  @Output() getOrderOutput = new EventEmitter<any>();

  constructor (
   private restaurantOrderFormService: RestaurantOrderFormService
  ) {}

  onGetOrderOutput(orderOutput: any) {
    this.getOrderOutput.emit(orderOutput);
  }

  ngOnInit() { }

  onSubmit() {
    this.createOrder();
  }

  createOrder() {
    this.errorMessage = "";
    this.orderInput = this.orderInput.toLowerCase();
    let orderSplitted = this.orderInput.replace(/\s/g, '').split(',');
    let period = orderSplitted.filter(a => a === 'morning' || a === 'night');
    let periodIndex = orderSplitted.findIndex(this.checkPeriod);

    if (period.length > 1 || periodIndex != 0) {
      this.errorMessage = `You must enter a valid input: a period of the time
        and the dishes separated by comma.`;
    } else {
      let isDuplicated = this.checkDuplicated(period[0], orderSplitted.slice(1));

      if(isDuplicated) {
        this.errorMessage = `You only can order 1 of each dish type.
          Exceptions: In the morning, you can order multiple cups of coffee;
          At night, you can have multiple orders of potatoes.`
      } else {
        this.sendOrder();
      }
    }
  }

  checkPeriod(order: string) {
    return order.toLowerCase() === 'morning' || order.toLowerCase() === 'night';
  }

  checkDuplicated(period: string, dishes: string[]): Boolean {
    for (var i = 0; i < dishes.length - 1; i++) {
      if (period === 'morning') {
        if (dishes[i + 1] === dishes[i] && dishes[i] != '3') {
          return true;
        }
      } else {
        if (dishes[i + 1] === dishes[i] && dishes[i] != '2') {
          return true;
        }
      }
    }
    return false;
  }

  async sendOrder() {
    this.order = new Order();
    this.order.setInputOrder(this.orderInput);
    await this.order.setOrderResponse(await this.restaurantOrderFormService.checkOrder(this.orderInput));
    this.orderOutput = this.order.getOrderResponse();
    this.onGetOrderOutput(this.order);
  }
}
