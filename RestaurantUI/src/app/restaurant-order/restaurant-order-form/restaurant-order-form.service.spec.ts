import { TestBed } from '@angular/core/testing';

import { RestaurantOrderFormService } from './restaurant-order-form.service';

describe('RestaurantOrderFormService', () => {
  let service: RestaurantOrderFormService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RestaurantOrderFormService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
