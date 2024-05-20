import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideFirebaseApp, initializeApp } from '@angular/fire/app'
import { getFirestore, provideFirestore } from '@angular/fire/firestore'

const firebaseConfig = {
  apiKey: "AIzaSyB4-MkFL1hCxCRgcsIPsJMSC6_s_DNOPkE",
  authDomain: "isport-team.firebaseapp.com",
  projectId: "isport-team",
  storageBucket: "isport-team.appspot.com",
  messagingSenderId: "880728253187",
  appId: "1:880728253187:web:6eca116b8f4d011b697f36"
};


export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideAnimationsAsync(),
    provideFirebaseApp(() => initializeApp(firebaseConfig)),
    provideFirestore(() => getFirestore()),
  ],
  
};
