import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../../service/auth/auth.service';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SnackBarComponent } from '../../snackbar/snackbar.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  currentForm: string = this.data.currentForm;
  loginForm: FormGroup;
  registerForm: FormGroup;
  logged: boolean = false;
  durationInSeconds = 1;

  constructor(
    private formBuilder: FormBuilder,
    private _authService: AuthService,
    private dialogClose: MatDialog,
    public _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });

    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit(): void {}

  toggleForm(formType: string) {
    this.currentForm = formType;
  }

  register() {
    this._authService
      .registerWithEmailAndPassword(
        this.registerForm.value.email,
        this.registerForm.value.password
      )
      .subscribe({
        next: () => {
          this.dialogClose.closeAll();
          this.openSnackBar('Success', true);
        },
        error: (err) => {
          this.openSnackBar('Failed', false);
        },
      });
  }

  login() {
    this._authService
      .signWithEmailAndPassword(
        this.loginForm.value.email,
        this.loginForm.value.password
      )
      .subscribe({
        next: (user) => {
          this.dialogClose.closeAll();
          this.openSnackBar('Sucess', true);
          window.location.reload();
        },
        error: (err) => {
          this.openSnackBar('Error', false);
        },
      });
  }

  openSnackBar(message: string, isMessageSuccessful: boolean) {
    const tailwindClass = isMessageSuccessful
      ? 'text-green-500'
      : 'text-red-400';

    this._snackBar.openFromComponent(SnackBarComponent, {
      duration: this.durationInSeconds * 1000,
      verticalPosition: 'top',
      horizontalPosition: 'end',
      data: { message: message, messageTailwindClass: tailwindClass},
      panelClass: ['w-600', 'py-20']
    });
  }
}
