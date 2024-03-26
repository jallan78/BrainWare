import { Route } from '@angular/router';
import { OrderComponent } from './order/order.component';

export const routes: Route[] = 
[ 
    { path: '', redirectTo: 'order', pathMatch: 'full'},
    { path: 'order', component: OrderComponent }
]; 


