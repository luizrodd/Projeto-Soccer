import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import * as firebase from 'firebase/app';
import { User } from '../../interfaces/user.interface';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private afAuth: AngularFireAuth, private router: Router) {}

  user: Observable<User> | undefined;

  signWithEmailAndPassword(email: string, password: string) {
    return this.afAuth
      .signInWithEmailAndPassword(email, password)
      .then((user) => {
        localStorage['token'] = user.user?.uid;
        this.router.navigate(['']);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  registerWithEmailAndPassword(email: string, password: string) {
    return this.afAuth.createUserWithEmailAndPassword(email, password);
  }

  logout() {
    return this.afAuth.signOut().then(() => {
      localStorage.removeItem('token');
      this.router.navigate(['']);
    });
  }
}
