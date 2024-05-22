import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivate } from "@angular/router";
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | boolean {
    const token = localStorage.getItem('token');

    // Use RxJS operators for cleaner logic
    return this.checkToken(token).pipe(
      tap((isAuthenticated) => {
        if (!isAuthenticated) {
          this.router.navigate(['/login']);
        }
      })
    );
  }

  private checkToken(token: string | null): Observable<boolean> {
    return token && token !== 'null' ? of(true) : of(false);
  }
}

// Helper function (optional, for reusability)
function of<T>(value: T): Observable<T> {
  return new Observable((subscriber) => {
    subscriber.next(value);
    subscriber.complete();
  });
}
