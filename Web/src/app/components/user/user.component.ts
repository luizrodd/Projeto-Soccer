import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/user/user.service';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user.component.html',
})
export class UserComponent implements OnInit {
  users$: Observable<any> | undefined;
  user = { name: '', email: '' }; // Add this line

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.users$ = this.userService.getUsers();
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
