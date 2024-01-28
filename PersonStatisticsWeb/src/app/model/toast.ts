import { ToastType } from 'src/enum/toastType';

export class Toast {
  constructor(
    public id: number,
    public type: ToastType,
    public message: string,
    public autoClose: boolean = false
  ) {}
}
