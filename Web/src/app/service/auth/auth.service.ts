import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import * as firebase from 'firebase/app';
import { User } from '../../interfaces/user.interface';
import { from, tap, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private afAuth: AngularFireAuth, private router: Router) {}

  user: Observable<User> | undefined;

  signWithEmailAndPassword(email: string, password: string): Observable<any> {
    return from(this.afAuth.signInWithEmailAndPassword(email, password))
      .pipe(
        tap((user) => {
          localStorage.setItem('token', user.user?.uid || '');
        }),
        catchError((error) => {
          console.error('Login error:', error);
          return throwError(error);
        })
      );
  }


  registerWithEmailAndPassword(email: string, password: string): Observable<any> {
    return from(this.afAuth.createUserWithEmailAndPassword(email, password));
  }

  logout() {
    return this.afAuth.signOut().then(() => {
      localStorage.removeItem('token');
      this.router.navigate(['']);
    });
  }
}
