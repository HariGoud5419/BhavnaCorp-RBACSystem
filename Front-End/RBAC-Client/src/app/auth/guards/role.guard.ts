import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from '../auth.service';
import { AuthUtils } from '../services/auth-utils';

/**
 * Route guard that restricts access based on user roles.
 * Applied to routes using `canActivate` with `data.roles`.
 */
@Injectable({
  providedIn: 'root',
})
export class RoleGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {}

  /**
   * Determines whether the route can be activated.
   * @param route The target route snapshot containing allowed roles.
   * @param state The router state.
   * @returns true if user is allowed; false otherwise (redirects to login).
   */
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    const token = localStorage.getItem('token');

    if (!token) {
      this.router.navigate(['/']);
      return false;
    }

    const userRoles = AuthUtils.getUserRoles(token); // Extract roles from JWT
    const requiredRoles = route.data['roles'] as string[];

    // Check if user has at least one of the required roles
    const hasAccess = requiredRoles.some((role) => userRoles.includes(role));

    if (!hasAccess) {
      this.router.navigate(['/dashboard']); // or a custom "Access Denied" page
    }

    return hasAccess;
  }
}
