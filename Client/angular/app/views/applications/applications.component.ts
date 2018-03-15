import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApplicationsService } from '../../services/client.services';
import { Applications } from '../../entities/btam-entities';

@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.css']
})
export class ApplicationsComponent implements OnInit {

  apps:Applications[]=[];
  app:Applications={};

  constructor(private appSvc : ApplicationsService, private router: Router){
  }

  async ngOnInit(){
    this.apps = <Applications[]> await this.appSvc.getApplications();
    /*
    this.apps= <Applications[]> await this.appSvc.getApplications();
    this.app = <Applications>await this.appSvc.getApplication("1");
    var app:Applications={AppMemberName:'sample',AppName:'name',Status:1}
    await console.log(this.apps);
    await console.log(this.app);
    var app1 = <Applications> await this.appSvc.postApplication(app);
    await console.log(app1);
    app1.Status=0;
    await this.appSvc.putApplication(app1);
    */
  }

  addApp(): void {
    this.router.navigate(['/ApplicationsAdd']);
  }

  editApp(id: string): void {
    this.router.navigate(['/ApplicationsEdit', id]);
  }

  deleteApp(id: string): void {
    this.router.navigate(['/ApplicationsDelete', id]);
  }
}
