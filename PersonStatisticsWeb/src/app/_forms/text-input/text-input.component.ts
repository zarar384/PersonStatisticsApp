import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css'],
})
export class TextInputComponent implements ControlValueAccessor {
  @Input() labelKey = '';
  @Input() type = 'text';

  constructor(
    private language: LanguageService,
    @Self() public ngControl: NgControl
  ) {
    this.ngControl.valueAccessor = this;
  }

  writeValue(obj: any): void {}
  registerOnChange(fn: any): void {}
  registerOnTouched(fn: any): void {}
  setDisabledState?(isDisabled: boolean): void {}

  get control(): FormControl {
    return this.ngControl.control as FormControl;
  }

  get label(): string {
    return this.language.toText(this.labelKey);
  }
}
