import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApplicationsService } from '../../../services/client.services';
import { Applications,Roles } from '../../../entities/btam-entities';

@Component({
  selector: 'app-applications-roles',
  templateUrl: './applications-roles.component.html',
  styleUrls: ['./applications-roles.component.css']
})
export class ApplicationsRolesComponent implements OnInit {

  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private appSvc : ApplicationsService,) { }

  roles:Roles[]=[];
  public app:Applications={};
  private appID : string;

  ngOnInit() {
    //this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.appID = this.activatedroute.snapshot.params['id'];
    this.appID!=null? this.getApplication():null;
  }

  async getApplication(){
    
    this.app =<Applications> await this.appSvc.getApplication(this.appID);
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsEdit', this.app.AppID],{skipLocationChange:true});
  }

  addRole(): void {
    this.router.navigate(['/ApplicationsRolesAdd'],{skipLocationChange:true});
  }

  deleteRole(role:Roles): void {
    this.router.navigate(['/ApplicationsRolesDelete',role],{skipLocationChange:true});
  }

  openRole(role:Roles): void {
    this.router.navigate(['/ApplicationsRolesEdit',role.RoleID],{skipLocationChange:true});
  }
}
