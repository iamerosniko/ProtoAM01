import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RolesService } from '../../../../services/client.services';
import { Applications,Roles } from '../../../../entities/btam-entities';

@Component({
  selector: 'app-applications-roles-form',
  templateUrl: './applications-roles-form.component.html',
  styleUrls: ['./applications-roles-form.component.css']
})
export class ApplicationsRolesFormComponent implements OnInit {

  constructor(private router:Router,private activatedroute: ActivatedRoute, private roleSvc : RolesService
    ) { }

  //public variables
  public FormLabelState:string;
  public role:Roles={};
  private roleID : string;
  public app:Applications={};

  ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.roleID = this.activatedroute.snapshot.params['id'];
    this.roleID!=null? this.getRole():null;
  }

  async getRole(){
    //this.role =<Roles> await this.roleSvc.getRole(this.roleID);
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsRoles', this.app.AppID],{skipLocationChange:true});
  }

}
