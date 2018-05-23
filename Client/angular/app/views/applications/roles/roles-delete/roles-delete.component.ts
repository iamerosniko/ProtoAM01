import { Router,ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { Roles } from '../../../../entities/btam-entities';
import { RolesService } from '../../../../services/client.services';

@Component({
  selector: 'app-applications-roles-delete',
  templateUrl: './roles-delete.component.html',
  styleUrls: ['./roles-delete.component.css']
})
export class ApplicationsRolesDeleteComponent implements OnInit {
  
  private appID:string;  
  role:Roles={};

  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private roleSvc :RolesService) { }

  ngOnInit() {
    this.activatedroute.params.subscribe(params => this.role = params);
    this.appID = this.activatedroute.snapshot.params['appID'];
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsRoles', this.appID],{skipLocationChange:true});
  }

  async delete() {
    var role:Roles =await this.roleSvc.deleteRole(this.role.RoleID.toString())
    role!=null
    ?(
      alert("Successfully deleted!"),
      await this.goBack()
    ):null;
  }
}
