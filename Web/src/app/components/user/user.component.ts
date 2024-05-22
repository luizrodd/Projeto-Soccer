import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/user/user.service';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './user.component.html',
})
export class UserComponent implements OnInit {
  users$: Observable<any> | undefined;
  user = { name: '', email: '' }; 

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.users$ = this.userService.getUsers();
    console.log(this.users$)
  }

  createUser(): void {
    if (!this.user.name || !this.user.email) {
      alert('Name and email are required');
      return;
    }

    this.userService.createUser(this.user).then(() => {
      this.users$ = this.userService.getUsers();
    });
  }
}
