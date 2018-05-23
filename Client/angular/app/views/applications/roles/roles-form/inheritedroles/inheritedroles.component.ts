import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { RolesService,InheritedRolesService } from '../../../../../services/client.services'
import { InheritedRoles,Roles } from '../../../../../entities/btam-entities'
@Component({
  selector: 'app-inheritedroles',
  templateUrl: './inheritedroles.component.html',
  styleUrls: ['./inheritedroles.component.css']
})
export class InheritedrolesComponent implements OnInit {

  constructor(private roleSvc : RolesService,
    private irSvc:InheritedRolesService,
    private router:Router,
    private activatedroute: ActivatedRoute) { }

  roleID:string;
  private appID : string;
  inheritedRoles:InheritedRoles[]=[];
  async ngOnInit() {
    this.appID =await this.activatedroute.snapshot.params['appID'];
    this.roleID =await this.activatedroute.snapshot.params['roleID'];
    this.inheritedRoles=<InheritedRoles[]> await this.irSvc.getRoles(this.appID,this.roleID);
  }

  async inheritRole(ir:InheritedRoles){
    ir.IsChecked=!ir.IsChecked;
    if(ir.IsChecked){
      ir=await this.irSvc.postInheritedRole(ir)
    }
    else 
    {
      ir=await this.irSvc.deleteInheritedRole(ir.InheritedRolesID.toString())
    }
    this.inheritedRoles=<InheritedRoles[]> await this.irSvc.getRoles(this.appID,this.roleID);
  }
}
