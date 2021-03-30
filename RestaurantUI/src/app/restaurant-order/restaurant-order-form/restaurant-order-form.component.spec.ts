import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantOrderFormComponent } from './restaurant-order-form.component';

describe('RestaurantOrderFormComponent', () => {
  let component: RestaurantOrderFormComponent;
  let fixture: ComponentFixture<RestaurantOrderFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantOrderFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantOrderFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
