import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule,ReactiveFormsModule }    from '@angular/forms';

import { ApplicationsComponent } from './applications.component';
import { ClientApiService, ClientApiSettings, ApplicationsService, RoleUsersService } from '../../services/client.services';
import { ApplicationsDeleteComponent } from './applications-delete/applications-delete.component';
import { ApplicationsFormComponent } from './applications-form/applications-form.component';
import { ApplicationsUsersComponent } from './applications-users/applications-users.component';
import { ApplicationsRolesComponent } from './applications-roles/applications-roles.component';
import { ApplicationsRolesDeleteComponent } from './applications-roles/applications-roles-delete/applications-roles-delete.component';
import { ApplicationsUsersDeleteComponent } from './applications-users/applications-users-delete/applications-users-delete.component';
import { ApplicationsUsersFormComponent } from './applications-users/applications-users-form/applications-users-form.component';
import { ApplicationsRolesFormComponent } from './applications-roles/applications-roles-form/applications-roles-form.component';
import { ApplicationsRolesUsersComponent } from './applications-roles/applications-roles-users/applications-roles-users.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,ReactiveFormsModule
  ],
  declarations: [ApplicationsComponent,  ApplicationsDeleteComponent, ApplicationsFormComponent, ApplicationsUsersComponent, ApplicationsRolesComponent, ApplicationsRolesDeleteComponent, ApplicationsUsersDeleteComponent, ApplicationsUsersFormComponent, ApplicationsRolesFormComponent, ApplicationsRolesUsersComponent],
  providers: [ClientApiService, ClientApiSettings, ApplicationsService,RoleUsersService]
})
export class ApplicationsModule { }
