import { Routes } from '@angular/router';
import { NewsComponent } from './components/news/news.component';
import { ScheduleComponent } from './components/schedule/schedule.component';
import { TeamsComponent } from './components/teams/teams.component';

export const routes: Routes = [
  {
    path: 'news',
    component: NewsComponent
  },
  {
    path: 'schedule',
    component: ScheduleComponent
  },
  {
    path: 'teams',
    component: TeamsComponent
  }
];
