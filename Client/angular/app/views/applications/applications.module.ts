import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }    from '@angular/forms';

import { ApplicationsComponent } from './applications.component';
import { ClientApiService, ClientApiSettings, ApplicationsService } from '../../services/client.services';
import { ApplicationsAddComponent } from './applications-add/applications-add.component';
import { ApplicationsEditComponent } from './applications-edit/applications-edit.component';
import { ApplicationsDeleteComponent } from './applications-delete/applications-delete.component';
import { ApplicationsDetailsComponent } from './applications-details/applications-details.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [ApplicationsComponent, ApplicationsAddComponent, ApplicationsEditComponent, ApplicationsDeleteComponent, ApplicationsDetailsComponent],
  providers: [ClientApiService, ClientApiSettings, ApplicationsService]
})
export class ApplicationsModule { }
