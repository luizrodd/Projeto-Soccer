import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { AngularFireModule } from '@angular/fire/compat';
import { AngularFireAuthModule } from '@angular/fire/compat/auth';
import { AngularFireDatabaseModule } from '@angular/fire/compat/database';
import { AngularFirestoreModule } from '@angular/fire/compat/firestore';
import { routes } from './app.routes';

const firebaseConfig = {
  databaseURL: "https://isport-team-default-rtdb.firebaseio.com",
  apiKey: 'AIzaSyB4-MkFL1hCxCRgcsIPsJMSC6_s_DNOPkE',
  authDomain: 'isport-team.firebaseapp.com',
  projectId: 'isport-team',
  storageBucket: 'isport-team.appspot.com',
  messagingSenderId: '880728253187',
  appId: '1:880728253187:web:6eca116b8f4d011b697f36',
};

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    importProvidersFrom(
      [AngularFireModule.initializeApp(firebaseConfig)],
      AngularFireAuthModule,
      AngularFireDatabaseModule,
      AngularFirestoreModule
    ),
  ],
};
