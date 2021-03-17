import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarlistComponent } from './components/carlist/carlist.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: CarlistComponent },
  { path: 'cars', component: CarlistComponent },
  { path: 'cars/brand/:brandId', component: CarlistComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}