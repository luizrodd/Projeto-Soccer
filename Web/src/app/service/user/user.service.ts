import { Injectable } from '@angular/core';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private firestore: AngularFirestore) { }

  getUsers(): Observable<any[]> {
    return this.firestore.collection('users').valueChanges();
  }

  getUser(userId: string): Observable<any> {
    return this.firestore.collection('users').doc(userId).valueChanges();
  }

  createUser(user: any): Promise<void> {
    return this.firestore.collection('users').add(user).then(() => {});
  }

  updateUser(userId: string, user: any): Promise<void> {
    return this.firestore.collection('users').doc(userId).update(user);
  }

  deleteUser(userId: string): Promise<void> {
    return this.firestore.collection('users').doc(userId).delete();
  }
}
