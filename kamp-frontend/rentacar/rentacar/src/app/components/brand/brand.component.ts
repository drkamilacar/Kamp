import { Component, OnInit, ɵEMPTY_ARRAY } from '@angular/core';
import { EMPTY } from 'rxjs';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { Brand } from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css'],
})
export class BrandComponent implements OnInit {
  brands: Brand[] = [];
   currentBrand: Brand;

  constructor(private brandService: BrandService) {}

  ngOnInit(): void {
    this.getBrands();
  }

  getBrands() {
    this.brandService.getBrands().subscribe((response) => {
      this.brands = response.data;
      // this.dataLoaded = true;
    });
  }

  setCurrentBrand(brand: Brand) {
    // console.log(category.categoryName);
    this.currentBrand = brand;
  }

  getCurrentCategoryClass(brand: Brand) {
    if (brand == this.currentBrand) {
      return 'list-group-item list-group-item-action active';
    } else {
      return 'list-group-item list-group-item-action';
    }
  }

  getAllCategoryClass() {
    if (!this.currentBrand) {
      return 'list-group-item list-group-item-action active';
    } else {
      return 'list-group-item list-group-item-action';
    }
  }
}
