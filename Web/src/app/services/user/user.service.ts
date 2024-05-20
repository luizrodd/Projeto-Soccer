import { Injectable } from '@angular/core';
import {  } from '@angular/fire/firestore';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private firestore: AngularFirestore) { }

  getUsers() {
    return this.firestore.collection('users').snapshotChanges();
  }

  addUser(user: any) {
    return this.firestore.collection('users').add(user);
  }

  updateUser(id: string, user: any) {
    return this.firestore.collection('users').doc(id).update(user);
  }

  deleteUser(id: string) {
    return this.firestore.collection('users').doc(id).delete();
  }
}
