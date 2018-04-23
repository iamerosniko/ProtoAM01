import { Router,ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Roles } from '../../../../entities/btam-entities';
import { RolesService } from '../../../../services/client.services';


@Component({
  selector: 'app-applications-roles-delete',
  templateUrl: './applications-roles-delete.component.html',
  styleUrls: ['./applications-roles-delete.component.css']
})
export class ApplicationsRolesDeleteComponent implements OnInit {
  role:Roles={};

  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private roleSvc :RolesService) { }

  ngOnInit() {
  }

  async delete() {
    // var role:Roles =await this.role.deleteApplication(this.app.AppID.toString())
    // app.AppID==this.app.AppID 
    // ?(
    //   alert("Successfully saved!"),
    //   await this.goBack()
    // ):null;
  }
}
