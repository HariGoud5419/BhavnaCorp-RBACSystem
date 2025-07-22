import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../../app/dashboard/dashboard/dashboard';
import { DashboardHomeComponent } from '../../app/dashboard/dashboard-home/dashboard-home';
import { AdminComponent } from './admin/admin';
import { EditorComponent } from './editor/editor';
import { ViewerComponent } from './viewer/viewer';
// Future: Add AdminGuard, EditorGuard, ViewerGuard here

/**
 * Routes for the dashboard module.
 * This area will be protected with route guards based on user roles.
 */
export const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      {
        path: '',
        component: DashboardHomeComponent, // dashboard root landing
      },
      {
        path: 'admin',
        component: AdminComponent,
      },
      {
        path: 'editor',
        component: EditorComponent,
      },
      {
        path: 'viewer',
        component: ViewerComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}
