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
  ngOnInit() {
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.roleID = this.activatedroute.snapshot.params['roleID'];
    this.getDependencies();
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
    // this.inheritedRoles=<InheritedRoles[]> await this.irSvc.getRoles(this.appID,this.roleID);
    this.getDependencies();
    
  }

  async getDependencies(){
    this.inheritedRoles=<InheritedRoles[]> await this.irSvc.getRoles(this.appID,this.roleID);
    this.inheritedRoles.forEach(async element => {
      element.InHeritedRoles = (await this.irSvc.getRoles(this.appID,element.RoleID));
      element.InHeritedRoles = await element.InHeritedRoles.filter(x=>x.IsChecked==true);
      element.IsEnabled=true;
      // console.log(element.inHeritedRoles.length);
      if(element.InHeritedRoles.length>0){
        var checkIfMeIsInherited = element.InHeritedRoles.find(x=>x.RoleID==this.roleID);
        if(checkIfMeIsInherited!=null){
          element.IsEnabled=false;
        }
        element.InHeritedRoles.forEach( irSub => {
          var test = this.inheritedRoles.find(x=>x.RoleID==irSub.RoleID)
          // console.log(test)
          if(test!=null){
            this.inheritedRoles=this.inheritedRoles.filter(x=>x.RoleID!=test.RoleID);
          }
        });
      
      }
    });
    await console.log(this.inheritedRoles);

  }
}
