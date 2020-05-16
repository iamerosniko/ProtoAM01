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

  constructor(private appSvc : ApplicationsService, private router: Router){
  }

  async ngOnInit(){
    await this.getDependencies();
  }

  addApp(): void {
    this.router.navigate(['/ApplicationsAdd']);
  }

  //deleteApp(id: string): void {
  deleteApp(app:Applications): void {
    this.router.navigate(['/ApplicationsDelete',app]);
    //this.router.navigate(['/ApplicationsDelete', id]);
  }

  //openApp(id: string): void {
  openApp(app:Applications): void {
    // this.router.navigate(['/ApplicationDetails']);
    this.router.navigate(['/ApplicationsEdit',app.AppID]);
    //this.router.navigate(['/ApplicationDetails', id]);
  }

  async getDependencies(){
    this.apps = <Applications[]> await this.appSvc.getApplications();
  }
}
