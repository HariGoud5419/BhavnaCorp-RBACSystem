import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { LoginRequestDto } from '../auth/models/login-request-dto';
import { LoginResponseDto } from '../auth/models/login-response-dto';
import { AuthUtils } from './services/auth-utils';

/**
 * AuthService handles all authentication-related HTTP operations.
 */
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly http = inject(HttpClient);

  private readonly apiUrl = 'http://localhost:5199/api/Auth/login'; // Update if needed

  /**
   * Sends login credentials to backend and returns JWT & user info.
   * @param payload - The login form data.
   */
  login(payload: LoginRequestDto): Observable<LoginResponseDto> {
    return this.http
      .post<LoginResponseDto>(this.apiUrl, payload)
      .pipe(catchError(this.handleError));
  }

  // logout functionality
  logout(): void {
    localStorage.removeItem('token'); // Remove token
    // Optionally clear more session data if you stored user context
  }

  /**
   * Centralized error handler for HTTP requests.
   */
  private handleError(error: HttpErrorResponse) {
    const errorMsg =
      error.error?.message || 'Login failed. Please try again later.';
    return throwError(() => new Error(errorMsg));
  }

  // Check whether the user has role or not
  hasRole(role: string): boolean {
    const token = localStorage.getItem('token');
    if (!token) return false;
    const roles = AuthUtils.getUserRoles(token);
    return roles.includes(role);
  }
}
