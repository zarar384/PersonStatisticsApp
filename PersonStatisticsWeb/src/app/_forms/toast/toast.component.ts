import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import { Observable, Subject, Subscription, of } from 'rxjs';
import { map, scan, switchMap } from 'rxjs/operators';
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
export class ToastComponent implements AfterViewInit {
  alerts$: Observable<Toast[]>;
  private subscription: Subscription;

  constructor(private toastService: ToastService) {}

  ngAfterViewInit(): void {
    this.alert();
    if (this.subscription) {
      this.clear();
    }
  }

  alert() {
    this.alerts$ = this.toastService.getAlert().pipe(
      switchMap((alert) => {
        if (alert) {
          return of([alert]);
        } else {
          return of([]);
        }
      })
    );

    this.subscription = this.alerts$.subscribe((alerts) => {});
  }

  removeAlert(currentAlert: Toast) {
    this.alerts$ = this.alerts$.pipe(
      map((alerts) => alerts.filter((alert) => alert !== currentAlert))
    );
  }

  clear() {
    this.toastService.clear();
    this.subscription.unsubscribe();
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
