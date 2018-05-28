import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component';
import { OthersModule } from './views/others/others.module';
import { AuthGuard } from './auth-guard.services';

import { FormsModule }    from '@angular/forms';

import { HttpModule } from '@angular/http'
import { ClientApiService,ClientApiSettings,
  ClientLoginService,
  ApplicationsService, UsersService, RolesService } from './services/client.services';

import { TopNavComponent } from './views/main/top-nav/top-nav.component';
import { ApplicationsModule } from './views/applications/applications.module';
import { TreeModule } from 'ng2-tree';
@NgModule({
  declarations: [
    AppComponent,
    TopNavComponent,
  ],
  imports: [
    TreeModule,
    HttpModule,
    FormsModule,
    BrowserModule,
    OthersModule,
    AppRoutingModule,
    ApplicationsModule
  ],
  providers: [AuthGuard, ClientApiService, ClientApiSettings, ClientLoginService,
    ApplicationsService,UsersService,RolesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
