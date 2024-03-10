import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AccountService } from '../services/account.service';
import { inject } from '@angular/core';
import { map, take } from 'rxjs/operators';

export const AccountGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const accountService = inject(AccountService);
  const router = inject(Router);

  return accountService.loggedIn().pipe(
    take(1),
    map((isLogin) => {
      if (!isLogin) {
        router.navigateByUrl('/');
        return false;
      }
      return true;
    })
  );
};
