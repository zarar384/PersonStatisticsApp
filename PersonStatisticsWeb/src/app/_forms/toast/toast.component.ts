import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map, scan } from 'rxjs/operators';
import { Toast } from 'src/app/model/toast';
import { ToastService } from 'src/app/services/toast.service';
import { ToastType } from 'src/enum/toastType';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrl: './toast.component.css',
  host: {
    class: 'toast-container position-fixed top-0 end-0 p-3',
    style: 'z-index: 1200',
  },
})
export class ToastComponent implements OnInit {
  alerts$: Observable<Toast[]>;

  constructor(private ToastService: ToastService) {}

  ngOnInit(): void {
    this.alert();
  }

  alert() {
    this.alerts$ = this.ToastService.getAlert().pipe(
      scan((acc: Toast[], value: Toast) => {
        if (value) {
          acc.push(value);
        } else {
          acc = [];
        }
        return acc;
      }, [])
    );
  }

  removeAlert(currentAlert: Toast) {
    this.alerts$ = this.alerts$.pipe(
      map((alerts) => alerts.filter((alert) => alert !== currentAlert))
    );
  }

  alertClass(alert: Toast) {
    var toastClass = '';

    switch (alert.type) {
      case ToastType.Success:
        toastClass = 'bg-success text-light';
        break;
      case ToastType.Error:
        toastClass = 'bg-danger text-light';
        break;
      case ToastType.Info:
        toastClass == 'bg-info text-light';
        break;
      case ToastType.Warning:
        toastClass == 'bg-warning text-light';
        break;
      default:
        break;
    }

    return toastClass;
  }
}
