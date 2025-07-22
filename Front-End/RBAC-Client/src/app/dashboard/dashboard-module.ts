import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing-module';
import { DashboardComponent } from './dashboard/dashboard';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home';
import { AdminComponent } from './admin/admin';

import { EditorComponent } from './editor/editor';
import { ViewerComponent } from './viewer/viewer';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    DashboardRoutingModule,
    DashboardComponent,
    DashboardHomeComponent,
    AdminComponent,
    EditorComponent,
    ViewerComponent,
  ],
})
export class DashboardModule {}
