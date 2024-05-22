import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginComponent } from '../user/login/login.component';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { ScheduleComponent } from '../schedule/schedule.component';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit{

  auth = localStorage.getItem('token')
  constructor(private router: Router, public dialog: MatDialog){}

  navigate(where: any){
    this.router.navigate(['/', where])
  }

  ngOnInit(): void {
    console.log(this.auth)
  }

  openDialogLogin(auth: string): void {
    const dialogRef = this.dialog.open(LoginComponent, {
      data: {currentForm: auth },
      width: '500px',
      height: '500px'
    });

    dialogRef.afterClosed().subscribe(() => {
      console.log('The dialog was closed');
    });
  }
}
