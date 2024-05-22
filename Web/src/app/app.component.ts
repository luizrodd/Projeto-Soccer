import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserComponent } from './components/user/user.component';
import { AngularFirestoreModule } from '@angular/fire/compat/firestore';
import { HttpClientModule } from '@angular/common/http';
import { AngularFireDatabase } from '@angular/fire/compat/database';
import { BannerComponent } from './components/banner/banner.component';
import { HeaderComponent } from './components/header/header.component';
import { ScheduleComponent } from './components/schedule/schedule.component';
import { LoginComponent } from './components/user/login/login.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, LoginComponent,HttpClientModule, ScheduleComponent, UserComponent, AngularFirestoreModule, BannerComponent, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(private db: AngularFireDatabase)
  {
    this.db.object('user').set({id: 1, name: 'John Doe', email: 'max@gmail.com'});
  }
}
