import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core';
import { AppRoutingModule } from './app/app-routing.module';

bootstrapApplication(App, {
  providers: [
    provideHttpClient(),
    importProvidersFrom(AppRoutingModule),
    // We can add more providers here like AuthGuard, Interceptors
  ],
}).catch((err) => console.error(err));
