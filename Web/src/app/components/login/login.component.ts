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
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogClose,
} from '@angular/material/dialog';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  currentForm: string = this.data.currentForm;
  loginForm: FormGroup;
  registerForm: FormGroup;
  logged: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private _authService: AuthService,
    private dialogClose: MatDialog,
    private router: Router,
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
      .then((res) => {
        this.router.navigateByUrl('/');
        window.location.reload();
      })
      .catch((error) => {
        console.log(error);
      });
  }

  login() {
    this._authService
      .signWithEmailAndPassword(
        this.loginForm.value.email,
        this.loginForm.value.password
      )
  }
}
