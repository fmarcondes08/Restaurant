export class Order {
  inputOrder!: Array<String>;
  orderError: string = '';
  orderResponse: string = '';

  constructor() {
  }

  public getInputOrder() {
    return this.inputOrder;
  }

  public setInputOrder(inputOrder: any) {
    this.inputOrder = inputOrder;
  }

  public getOrderResponse() {
    return this.orderResponse;
  }

  public setOrderResponse(response: string) {
    this.orderResponse = response;
  }
}
