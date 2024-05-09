import { CUSTOM_ELEMENTS_SCHEMA, Component } from '@angular/core';
import 'date-carousel/date-carousel.js';
import { CardComponent } from './card/card.component';

@Component({
  selector: 'app-schedule',
  standalone: true,
  imports: [CardComponent],
  templateUrl: './schedule.component.html',
  styleUrl: './schedule.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class ScheduleComponent {
  onWeekChange($event: Event) {
    throw new Error('Method not implemented.');
  }
  onDayPick($event: Event) {
    throw new Error('Method not implemented.');
  }
}
