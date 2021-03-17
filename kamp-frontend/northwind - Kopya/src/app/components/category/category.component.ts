import { Component, OnInit, ɵEMPTY_ARRAY } from '@angular/core';
import { EMPTY } from 'rxjs';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
})
export class CategoryComponent implements OnInit {
  categories: Category[] = [];
  //currentCategory: Category = { categoryId: 0, categoryName: '' };
  currentCategory: Category;

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((response) => {
      this.categories = response.data;
      // this.dataLoaded = true;
    });
  }

  setCurrentCategory(category: Category) {
    // console.log(category.categoryName);
    this.currentCategory = category;
  }

  getCurrentCategoryClass(category: Category) {
    if (category == this.currentCategory) {
      return 'list-group-item list-group-item-action active';
    } else {
      return 'list-group-item list-group-item-action';
    }
  }

  getAllCategoryClass() {
    if (!this.currentCategory) {
      return 'list-group-item list-group-item-action active';
    } else {
      return 'list-group-item list-group-item-action';
    }
  }
  // getCurrentCategoryClass(category: Category) {
  //   if (category == this.currentCategory) {
  //     return 'list-group-item active';
  //   } else {
  //     return 'list-group-item';
  //   }
  // }
}
