import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule,ReactiveFormsModule }    from '@angular/forms';

import { TabsModule } from 'ngx-bootstrap/tabs';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { ApplicationsComponent } from './applications.component';
import { ClientApiService, ClientApiSettings, ApplicationsService,
  RoleUsersService, ServicesService, InheritedRolesService,ServiceAttributesService } from '../../services/client.services';
import { ApplicationsDeleteComponent } from './applications-delete/applications-delete.component';
import { ApplicationsFormComponent } from './applications-form/applications-form.component';
import { ApplicationsUsersComponent } from './users/users.component';
import { ApplicationsRolesComponent } from './roles/roles.component';
import { ApplicationsRolesDeleteComponent } from './roles/roles-delete/roles-delete.component';
import { ApplicationsUsersDeleteComponent } from './users/users-delete/users-delete.component';
import { ApplicationsUsersFormComponent } from './users/users-form/users-form.component';
import { ApplicationsRolesFormComponent } from './roles/roles-form/roles-form.component';
import { ApplicationsRolesUsersComponent } from './roles/roles-users/roles-users.component';
import { ServicesComponent } from './roles/roles-form/services/services.component';
import { ServicesDeleteComponent } from './roles/roles-form/services/services-delete/services-delete.component';
import { ServicesFormComponent } from './roles/roles-form/services/services-form/services-form.component';
import { InheritedrolesComponent } from './roles/roles-form/inheritedroles/inheritedroles.component';
import { AttributesComponent } from './roles/roles-form/services/services-form/attributes/attributes.component';
import { AttributesFormComponent } from './roles/roles-form/services/services-form/attributes/attributes-form/attributes-form.component';
import { AttributesDeleteComponent } from './roles/roles-form/services/services-form/attributes/attributes-delete/attributes-delete.component';

@NgModule({
  imports: [
    CommonModule,
    TabsModule.forRoot(),
    PaginationModule.forRoot(),
    FormsModule,ReactiveFormsModule
  ],
  declarations: [ApplicationsComponent,  ApplicationsDeleteComponent, ApplicationsFormComponent, ApplicationsUsersComponent, ApplicationsRolesComponent, ApplicationsRolesDeleteComponent, ApplicationsUsersDeleteComponent, ApplicationsUsersFormComponent, ApplicationsRolesFormComponent, ApplicationsRolesUsersComponent, ServicesComponent, ServicesDeleteComponent, ServicesFormComponent, InheritedrolesComponent, AttributesComponent, AttributesFormComponent, AttributesDeleteComponent],
  providers: [ClientApiService, ClientApiSettings, ApplicationsService, RoleUsersService, ServicesService, InheritedRolesService, ServiceAttributesService]
})
export class ApplicationsModule { }
