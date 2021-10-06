import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'rg'
})
export class RgPipe implements PipeTransform {

  transform(value: string|number): string {
    let valorFormatado = value + '';

        valorFormatado = valorFormatado
            .padStart(12)                  // item 1
            .substr(0, 12)                      // item 2
            .replace(/[^0-9]/, '')              // item 3
            .replace(                           // item 4
                /(\d{2})(\d{3})(\d{3})(\d{2})/,
                '$1.$2.$3-$4'
            );

        return valorFormatado;
  }

}
