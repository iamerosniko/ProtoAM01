import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component';
import { OthersModule } from './views/others/others.module';
import { AuthGuard } from './auth-guard.services';

import { FormsModule }    from '@angular/forms';

import { HttpModule } from '@angular/http'
import { ClientApiService,ClientApiSettings,
  ClientLoginService,CompanyProfilesService,
  ApplicationsService, UsersService } from './services/client.services';

import { TopNavComponent } from './views/main/top-nav/top-nav.component';
import { ApplicationsModule } from './views/applications/applications.module';
import { ApplicationsUsersComponent } from './views/applications-users/applications-users.component';

@NgModule({
  declarations: [
    AppComponent,
    TopNavComponent,
    ApplicationsUsersComponent
  ],
  imports: [
    HttpModule,
    FormsModule,
    BrowserModule,
    OthersModule,
    AppRoutingModule,
    ApplicationsModule
  ],
  providers: [AuthGuard, ClientApiService, ClientApiSettings, ClientLoginService,
    CompanyProfilesService,ApplicationsService,UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
