import { Directive, ElementRef, Input } from '@angular/core';
import { ApiService } from '../services/api.service';
import { ITranslate } from '../interfaces/ITranslate';
import * as xml2js from 'xml2js';

@Directive({
  selector: '[setTextField]',
})
export class TextfieldChangedDirective {
  @Input() setTextField: string;

  constructor(private api: ApiService, private el: ElementRef) {}

  ngOnInit() {
    this.api.loadXML().subscribe((data) => {
      this.parseXML(data, this.setTextField).then((data) => {
        if (data != null || data != undefined) {
          (this.el.nativeElement as HTMLElement).textContent = data as string;
        }
      });
      (this.el.nativeElement as HTMLElement).textContent = this.setTextField;
    });
  }

  parseXML(data: string, fieldName: string) {
    return new Promise((resolve) => {
      var k: string | number,
        arr: Array<ITranslate> = [],
        parser = new xml2js.Parser({
          trim: true,
          explicitArray: true,
        });
      parser.parseString(data, function (err: any, result: { ru: any }) {
        var obj = result.ru;
        for (k in obj.field) {
          var item = obj.field[k];
          var id = item.value[0];
          if (id['$'].id === fieldName) {
            arr.push({
              value: item.value[0]._,
            });
          }
        }
        resolve(arr[0].value);
      });
    });
  }
}
