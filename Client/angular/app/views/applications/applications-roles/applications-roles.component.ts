import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RolesService } from '../../../services/client.services';
import { Roles } from '../../../entities/btam-entities';

@Component({
  selector: 'app-applications-roles',
  templateUrl: './applications-roles.component.html',
  styleUrls: ['./applications-roles.component.css']
})
export class ApplicationsRolesComponent implements OnInit {

  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private roleSvc :RolesService) { }

  roles:Roles[]=[];
  private appID : string;

  ngOnInit() {
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.appID!=null? this.getRoles():null;
  }

  async getRoles(){
    this.roles =<Roles[]> await this.roleSvc.getRoles(this.appID);
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsEdit', this.appID],{skipLocationChange:true});
  }

  addRole(): void {
    this.router.navigate(['/ApplicationsRolesAdd',this.appID],{skipLocationChange:true});
  }

  deleteRole(role:Roles): void {
    this.router.navigate(['/ApplicationsRolesDelete',this.appID,role],{skipLocationChange:true});
  }

  openRole(role:Roles): void {
    this.router.navigate(['/ApplicationsRolesEdit',role.RoleID,this.appID],{skipLocationChange:true});
  }
}
