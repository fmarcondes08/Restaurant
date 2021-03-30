import { Inject, Injectable } from '@angular/core';
import { ServiceInterface } from 'src/app/interfaces/service.interface';
import { Order } from 'src/app/models/Order';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RestaurantOrderFormService implements ServiceInterface<Order>{
  private http: HttpClient;
  private apiUrl: string;

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.http = http;
    this.apiUrl = apiUrl;
  }

  async checkOrder(order: string): Promise<any> {
    return new Promise(resolve => {
      this.http.get<Order>(this.apiUrl + 'api/order?input=' + order)
        .subscribe(
          async result => {
            resolve(this.handleResult(result));
          },
          error => this.handleError(error)
        );
    });
  }

  handleResult(result: Order): string {
    return result.orderResponse;
  }

  handleError(error: HttpErrorResponse) {
    console.error(error);
    this.displayError(error.error.input);
    return '';
  }

  private displayError(error: string) {
    if (error) {
      alert(error);
      return;
    }
    alert("There is something wrong with your order.");
  }
}
