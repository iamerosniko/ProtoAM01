import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NoaccessComponent } from './views/others/noaccess/noaccess.component';
import { LoginComponent } from './views/others/login/login.component';
import { LogoutComponent } from './views/others/logout/logout.component';
import { RedirectingComponent } from './views/others/redirecting/redirecting.component';

import {
  ApplicationsComponent,ApplicationsDeleteComponent,ApplicationsFormComponent,ApplicationsRolesComponent,ApplicationsUsersComponent,
  ApplicationsRolesFormComponent,ApplicationsUsersFormComponent,ApplicationsRolesDeleteComponent,ApplicationsUsersDeleteComponent,
  ServicesFormComponent,ServicesDeleteComponent,AttributesDeleteComponent,AttributesFormComponent
} from './views/applications/applications'

import { AuthGuard } from './auth-guard.services';
const routes: Routes = [
  { path: '', redirectTo:'/Login', pathMatch: "full" },
  { path: 'Login', component: LoginComponent},
  //applications
  { path: 'Applications', component : ApplicationsComponent, canActivate:[AuthGuard]},
  { path: 'ApplicationsAdd', component : ApplicationsFormComponent, canActivate:[AuthGuard]},
  { path: 'ApplicationsEdit/:id', component : ApplicationsFormComponent, canActivate:[AuthGuard]},
  { path: 'ApplicationsDelete', component : ApplicationsDeleteComponent, canActivate:[AuthGuard]},
  //users
  { path: 'ApplicationsUsers/:appID', component: ApplicationsUsersComponent, canActivate:[AuthGuard] },
  { path: 'ApplicationsUsersAdd/:appID', component: ApplicationsUsersFormComponent , canActivate:[AuthGuard]},
  { path: 'ApplicationsUsersEdit/:userID/:appID', component: ApplicationsUsersFormComponent, canActivate:[AuthGuard] },
  { path: 'ApplicationsUsersDelete/:appID', component: ApplicationsUsersDeleteComponent, canActivate:[AuthGuard] },
  //roles
  { path: 'ApplicationsRoles/:appID', component: ApplicationsRolesComponent, canActivate:[AuthGuard] },
  { path: 'ApplicationsRolesAdd/:appID', component: ApplicationsRolesFormComponent, canActivate:[AuthGuard] },
  { path: 'ApplicationsRolesEdit/:roleID/:appID', component: ApplicationsRolesFormComponent, canActivate:[AuthGuard] },
  { path: 'ApplicationsRolesDelete/:appID', component: ApplicationsRolesDeleteComponent, canActivate:[AuthGuard] },
  //services
  { path: 'ServicesAdd/:roleID/:appID', component:ServicesFormComponent, canActivate:[AuthGuard]},
  { path: 'ServicesEdit/:roleID/:appID/:serviceID', component:ServicesFormComponent, canActivate:[AuthGuard]},
  { path: 'ServicesDelete/:roleID/:appID/:serviceID',component:ServicesDeleteComponent, canActivate:[AuthGuard]},
  //attributes
  { path: 'AttributesAdd/:roleID/:appID/:serviceID',component:AttributesFormComponent, canActivate:[AuthGuard]},
  { path: 'AttributesEdit/:roleID/:appID/:serviceID/:attributeID',component:AttributesFormComponent, canActivate:[AuthGuard]},
  { path: 'AttributesDelete/:roleID/:appID/:serviceID/:attributeID',component:AttributesDeleteComponent, canActivate:[AuthGuard]},
  // { path: 'Reports', component : ReportsComponent },
  // { path: 'Survey', component : SurveysComponent},
 

  // { path: '', redirectTo:'/Login', pathMatch:"full" },
  // { path: 'Login', component:LoginComponent},
  { path: 'Redirecting', component : RedirectingComponent},
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
