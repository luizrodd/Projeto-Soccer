import { CommonModule } from '@angular/common';
import { Component, Inject, Input, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import {
  MAT_SNACK_BAR_DATA,
  MatSnackBarAction,
  MatSnackBarActions,
  MatSnackBarLabel,
  MatSnackBarRef,
} from '@angular/material/snack-bar';

@Component({
  selector: 'app-snack-bar',
  standalone: true,
  imports: [
    MatButtonModule,
    MatSnackBarLabel,
    MatSnackBarActions,
    MatSnackBarAction,
    CommonModule,
    MatIcon,
  ],
  templateUrl: './snackbar.component.html',
})
export class SnackBarComponent {
  message: string;
  messageTailwindClass: string;

  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: any) {
    this.message = data.message;
    this.messageTailwindClass = data.messageTailwindClass
      ? data.messageTailwindClass
      : 'text-gray-300';
  }

  snackBarRef = inject(MatSnackBarRef);
}
