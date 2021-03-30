import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RestaurantOrderComponent } from './restaurant-order/restaurant-order.component';
import { RestaurantOrderFormComponent } from './restaurant-order/restaurant-order-form/restaurant-order-form.component';
import { RestaurantGridResultsComponent } from './restaurant-grid-results/restaurant-grid-results.component';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantOrderComponent,
    RestaurantOrderFormComponent,
    RestaurantGridResultsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
