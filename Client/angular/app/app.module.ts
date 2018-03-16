import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component';
import { OthersModule } from './views/others/others.module';
import { AuthGuard } from './auth-guard.services';
import { HttpModule } from '@angular/http'
import { ClientApiService,ClientApiSettings,
  ClientLoginService,CompanyProfilesService,
  ApplicationsService, UsersService } from './services/client.services';
import { TopNavComponent } from './views/main/top-nav/top-nav.component';
import { ApplicationsModule } from './views/applications/applications.module';

@NgModule({
  declarations: [
    AppComponent,
    TopNavComponent
  ],
  imports: [
    HttpModule,
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
