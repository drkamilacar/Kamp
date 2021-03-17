import { StringMap } from '@angular/compiler/src/compiler_facade_interface';
import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../models/product';

@Pipe({
  name: 'filterPipe',
})
export class FilterPipePipe implements PipeTransform {
  transform(value: Product[], filterText: string): Product[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : '';
    return filterText
      ? value.filter(
          (p: Product) =>
            p.productName.toLocaleLowerCase().includes(filterText) == true
        )
      : value;
  }
}
