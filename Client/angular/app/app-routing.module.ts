import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NoaccessComponent } from './views/others/noaccess/noaccess.component';
import { LoginComponent } from './views/others/login/login.component';
import { LogoutComponent } from './views/others/logout/logout.component';
import { RedirectingComponent } from './views/others/redirecting/redirecting.component';

// import { ApplicationsComponent } from  './views/applications/applications.component';
// import { ApplicationsAddComponent } from  './views/applications/applications-add/applications-add.component';
// import { ApplicationsEditComponent } from  './views/applications/applications-edit/applications-edit.component';
// import { ApplicationsDeleteComponent } from  './views/applications/applications-delete/applications-delete.component';
// import { ApplicationsDetailsComponent } from './views/applications/applications-details/applications-details.component';

import {
  ApplicationsComponent,ApplicationsDeleteComponent,ApplicationsFormComponent,ApplicationsRolesComponent,ApplicationsUsersComponent,
  ApplicationsRolesFormComponent,ApplicationsUsersFormComponent,ApplicationsRolesDeleteComponent,ApplicationsUsersDeleteComponent,
  ServicesFormComponent,ServicesDeleteComponent
} from './views/applications/applications'

import { AuthGuard } from './auth-guard.services';
const routes: Routes = [
  { path: '', redirectTo:'/Login', pathMatch: "full" },
  { path: 'Login', component: LoginComponent},
  //applications
  { path: 'Applications', component : ApplicationsComponent},
  { path: 'ApplicationsAdd', component : ApplicationsFormComponent},
  { path: 'ApplicationsEdit/:id', component : ApplicationsFormComponent},
  { path: 'ApplicationsDelete', component : ApplicationsDeleteComponent},
  //users
  { path: 'ApplicationsUsers/:appID', component: ApplicationsUsersComponent },
  { path: 'ApplicationsUsersAdd/:appID', component: ApplicationsUsersFormComponent },
  { path: 'ApplicationsUsersEdit/:userID/:appID', component: ApplicationsUsersFormComponent },
  { path: 'ApplicationsUsersDelete/:appID', component: ApplicationsUsersDeleteComponent },
  //roles
  { path: 'ApplicationsRoles/:appID', component: ApplicationsRolesComponent },
  { path: 'ApplicationsRolesAdd/:appID', component: ApplicationsRolesFormComponent },
  { path: 'ApplicationsRolesEdit/:roleID/:appID', component: ApplicationsRolesFormComponent },
  { path: 'ApplicationsRolesDelete/:appID', component: ApplicationsRolesDeleteComponent },
  //services
  { path: 'ServicesAdd/:roleID/:appID', component:ServicesFormComponent},
  { path: 'ServicesEdit/:roleID/:appID/:serviceID', component:ServicesFormComponent},
  { path: 'ServicesDelete/:roleID/:appID/:serviceID',component:ServicesDeleteComponent},
  // { path: 'Reports', component : ReportsComponent },
  // { path: 'Survey', component : SurveysComponent},
 

  // { path: '', redirectTo:'/Login', pathMatch:"full" },
  // { path: 'Login', component:LoginComponent},
  // { path: 'Redirecting', component : RedirectingComponent},
  // { path: 'Logout', component:LogoutComponent},
  // { path: 'Noaccess', component:NoaccessComponent},
  // { path: '**', redirectTo :'/Survey' },
  // { path: 'Survey', component : SurveysComponent, canActivate:[AuthGuard] },
  // { path: 'Reports', component : ReportsComponent, canActivate:[AuthGuard] },


  { path: '**', redirectTo :'/Login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash:true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
