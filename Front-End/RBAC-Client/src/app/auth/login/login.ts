import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { LoginRequestDto } from '../models/login-request-dto';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router } from '@angular/router';

/**
 * LoginComponent handles user authentication form submission and validation.
 */
@Component({
  selector: 'app-login',
  standalone: true, // standalone component
  imports: [
    ReactiveFormsModule, // Required for [formGroup]
  ],
  templateUrl: './login.html',
  styleUrls: ['./login.scss'],
})
export class LoginComponent {
  loginForm: FormGroup;
  loginError: string | null = null; // Error message placeholder

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    //initializing the form
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  /**
   * Handles form submission logic.
   */
  onSubmit(): void {
    if (this.loginForm.valid) {
      const payload: LoginRequestDto = this.loginForm.value;

      this.authService.login(payload).subscribe({
        next: (response) => {
          console.log('Login Success:', response);
          //using this for the assignment purpose as we are used JWT bearer auth from headers)
          localStorage.setItem('token', response.token); // storing JWT token

          // Read roles from response (assuming they exist)
          const roles = response.roles || [];

          // Navigate to appropriate dashboard page
          if (roles.includes('Admin')) {
            this.router.navigate(['/dashboard/admin']);
          } else if (roles.includes('Editor')) {
            this.router.navigate(['/dashboard/editor']);
          } else if (roles.includes('Viewer')) {
            this.router.navigate(['/dashboard/viewer']);
          } else {
            this.router.navigate(['/dashboard']); // fallback
          }
        },
        error: (err) => {
          console.error('Login Error:', err.message);
          this.loginError = 'Invalid credentials or server error.';
          alert(err.message); // Replace with toast in future
        },
      });
    }
  }
}
