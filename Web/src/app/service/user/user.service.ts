import { Injectable, inject } from '@angular/core';
import { AngularFireDatabase, AngularFireList } from '@angular/fire/compat/database';
import {
  Firestore,
  addDoc,
  collection,
  collectionData,
  deleteDoc,
  doc,
  getDoc,
  getDocs,
  query,
  updateDoc,
  where,
} from '@angular/fire/firestore';
import { Observable } from 'rxjs';
const PATH = 'user';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private _firestore = inject(Firestore);

  private _collection = collection(this._firestore, PATH);

  getAll(){
    return collectionData(this._collection) as Observable<any>;
  }
}
