import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Toast } from '../model/toast';
import { ToastType } from 'src/enum/toastType';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  private alertSubj = new Subject<Toast>();
  private id = 0;

  constructor() {}

  getAlert() {
    return this.alertSubj.asObservable();
  }

  addAlert(type: ToastType, message: string, autoClose: boolean = false) {
    this.alertSubj.next(new Toast(++this.id, type, message, autoClose));
  }

  clear(id?: number) {
    id ? this.alertSubj.next(new Toast(id, null, '')) : this.alertSubj.next();
  }
}
