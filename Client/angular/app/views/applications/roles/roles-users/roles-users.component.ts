import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Users,Roles,UserRoles } from '../../../../entities/btam-entities';
import { RolesService, UsersService, RoleUsersService } from '../../../../services/client.services';

@Component({
  selector: 'app-applications-roles-users',
  templateUrl: './roles-users.component.html',
  styleUrls: ['./roles-users.component.css']
})

export class ApplicationsRolesUsersComponent implements OnInit {
  private roleID : string;
  private appID : string;
  //list of all users
  userLists:Users[]=[];
  users:UserRoles[]=[];
  //users with no roles yet
  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private userSvc:UsersService, private roleUserSvc:RoleUsersService) { 
    
  }
  async getUsers(){
    this.userLists = await this.userSvc.getUsers(this.appID);
    this.userLists.forEach(async user => {
      
      this.users= this.users.concat(
        {
          FirstName:user.FirstName,
          LastName:user.LastName,
          Role:user.Role,
          RoleID:user.RoleID,
          UserAppID:user.UserAppID,
          UserID:user.UserID,
          UserName:user.UserName,
          IsChecked:(user.RoleID == this.roleID)?true:false,
          
        }
      )

    });

    this.users = await this.users.filter(x=>x.RoleID=="0" || x.RoleID == this.roleID) ;
  }
  
  ngOnInit() {
    this.roleID = this.activatedroute.snapshot.params['roleID'];
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.appID!=null? this.getUsers():null;
  }
  
  async changePermission(user:UserRoles){
    console.log(user)
    user.RoleID=this.roleID;
    user.IsChecked=!user.IsChecked;
    var a = await this.roleUserSvc.postRole(user);
    console.log(a)
  }

}
