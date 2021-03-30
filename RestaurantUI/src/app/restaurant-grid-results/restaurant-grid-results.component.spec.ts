import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantGridResultsComponent } from './restaurant-grid-results.component';

describe('RestaurantGridResultsComponent', () => {
  let component: RestaurantGridResultsComponent;
  let fixture: ComponentFixture<RestaurantGridResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantGridResultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantGridResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
