import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login'; // standalone component
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
  imports: [
    CommonModule, // For ngIf, ngFor, etc.
    ReactiveFormsModule, // For reactive form support
    AuthRoutingModule, // Routes for this module
    LoginComponent, // as we are using standalone component we are not declaring instead importing here
  ],
})
export class AuthModule {}
