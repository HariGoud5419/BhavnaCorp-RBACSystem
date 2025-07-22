export class AuthUtils {
  /**
   * Decodes a JWT and returns the roles array.
   * Assumes the token contains a `role` claim (array of strings).
   */
  static getUserRoles(token: string): string[] {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return Array.isArray(payload.role) ? payload.role : [payload.role];
    } catch (e) {
      console.error('Invalid token:', e);
      return [];
    }
  }
}
