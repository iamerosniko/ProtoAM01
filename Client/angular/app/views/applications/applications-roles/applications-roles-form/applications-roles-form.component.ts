import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RolesService } from '../../../../services/client.services';
import { Roles } from '../../../../entities/btam-entities'

@Component({
  selector: 'app-applications-roles-form',
  templateUrl: './applications-roles-form.component.html',
  styleUrls: ['./applications-roles-form.component.css']
})
export class ApplicationsRolesFormComponent implements OnInit {

  constructor(private router:Router,private activatedroute: ActivatedRoute, 
    private roleSvc : RolesService,private fb:FormBuilder
    ) { }

  //public variables
  public FormLabelState:string;
  public role:Roles={};
  roleForm = new FormGroup({
  });
  private roles:Roles[]=[];
  //private variables
  public roleID : string;
  private appID:string;

  ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.roleID = this.activatedroute.snapshot.params['roleID'];
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.roleID!=null? this.getRole():null;
    
    this.roleForm = this.fb.group({
      RoleName : [this.role.RoleName,Validators.required],
    });
  }

  async getRole(){
    this.roles =<Roles[]> await this.roleSvc.getRoles(this.appID);    
    this.role = <Roles> await this.roles.find(x=>x.RoleID == this.roleID);
  
    this.roleForm = this.fb.group({
      RoleID:[this.role.RoleID,Validators.required],
      RoleName : [this.role.RoleName,Validators.required],
    });
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsRoles', this.appID],{skipLocationChange:true});
  }

  gotoServices():void{
    this.router.navigate(['/ServicesAdd',this.roleID,this.appID],{skipLocationChange:true});
  }

  async save() {
    this.role=await this.roleForm.value;
    var role:Roles ={};
    if(this.role.RoleID==null){
      role = <Roles> await this.roleSvc.postRole(this.appID,this.role);
    }
    else{
      role = <Roles> await this.roleSvc.putRole(this.roleID,this.role);
    }
    if(role!=null)
    {
      await alert("Successfully saved!");
      this.goBack();
    }  
  }

}
