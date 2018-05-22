import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule,ReactiveFormsModule }    from '@angular/forms';

import { TabsModule } from 'ngx-bootstrap/tabs';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { ApplicationsComponent } from './applications.component';
import { ClientApiService, ClientApiSettings, ApplicationsService,
  RoleUsersService, ServicesService, InheritedRolesService } from '../../services/client.services';
import { ApplicationsDeleteComponent } from './applications-delete/applications-delete.component';
import { ApplicationsFormComponent } from './applications-form/applications-form.component';
import { ApplicationsUsersComponent } from './applications-users/applications-users.component';
import { ApplicationsRolesComponent } from './applications-roles/applications-roles.component';
import { ApplicationsRolesDeleteComponent } from './applications-roles/applications-roles-delete/applications-roles-delete.component';
import { ApplicationsUsersDeleteComponent } from './applications-users/applications-users-delete/applications-users-delete.component';
import { ApplicationsUsersFormComponent } from './applications-users/applications-users-form/applications-users-form.component';
import { ApplicationsRolesFormComponent } from './applications-roles/applications-roles-form/applications-roles-form.component';
import { ApplicationsRolesUsersComponent } from './applications-roles/applications-roles-users/applications-roles-users.component';
import { ServicesComponent } from './applications-roles/applications-roles-form/services/services.component';
import { ServicesDeleteComponent } from './applications-roles/applications-roles-form/services/services-delete/services-delete.component';
import { ServicesFormComponent } from './applications-roles/applications-roles-form/services/services-form/services-form.component';
import { InheritedrolesComponent } from './applications-roles/applications-roles-form/inheritedroles/inheritedroles.component';

@NgModule({
  imports: [
    CommonModule,
    TabsModule.forRoot(),
    PaginationModule.forRoot(),
    FormsModule,ReactiveFormsModule
  ],
  declarations: [ApplicationsComponent,  ApplicationsDeleteComponent, ApplicationsFormComponent, ApplicationsUsersComponent, ApplicationsRolesComponent, ApplicationsRolesDeleteComponent, ApplicationsUsersDeleteComponent, ApplicationsUsersFormComponent, ApplicationsRolesFormComponent, ApplicationsRolesUsersComponent, ServicesComponent, ServicesDeleteComponent, ServicesFormComponent, InheritedrolesComponent],
  providers: [ClientApiService, ClientApiSettings, ApplicationsService, RoleUsersService, ServicesService, InheritedRolesService]
})
export class ApplicationsModule { }
