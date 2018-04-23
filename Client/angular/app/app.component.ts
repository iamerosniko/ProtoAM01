import { Component,OnInit } from '@angular/core';
import { ApplicationsService, UsersService,RolesService } from './services/client.services';
import { Applications,Users,Roles } from './entities/btam-entities';
import { MyHttpResponse } from './services/httpresponse';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  
  apps:Applications[]=[];
  app:Applications={};

  users:Users[]=[];
  user:Users={};

  roles:Roles[]=[];
  role:Roles={};

  async ngOnInit(){
  //  this.apps= <Applications[]> await this.appSvc.getApplications();
  //  this.app = <Applications>await this.appSvc.getApplication("1");
  //  var app:Applications={AppMemberName:'sample',AppName:'name',Status:1}
  //  await console.log(this.apps);
  //  await console.log(this.app);
  //  var app1 = <Applications> await this.appSvc.postApplication(app);
  //  await console.log(app1);
  //  app1.Status=0;
  //  await this.appSvc.putApplication(app1);

    this.users= <Users[]> await this.userSvc.getUsers(1);
    console.log(this.users);
    this.testRole();
  }

  constructor(private appSvc : ApplicationsService,
    private userSvc:UsersService,private roleSvc:RolesService){
    
  }

  async testRole(){
    console.log(await this.roleSvc.getRoles('1'));
  }
  async testUsers(){

  }
}
