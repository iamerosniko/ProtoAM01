import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from '../../../services/client.services';
import { Users } from '../../../entities/btam-entities';

@Component({
  selector: 'app-applications-users',
  templateUrl: './applications-users.component.html',
  styleUrls: ['./applications-users.component.css']
})
export class ApplicationsUsersComponent implements OnInit {

  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private userSvc:UsersService) { }

  users:Users[]=[];
  private appID : string;

  ngOnInit() {
    //this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.appID!=null? this.getUsers():null;
  }

  async getUsers(){
    this.users = await this.userSvc.getUsers(this.appID);
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsEdit', this.appID],{skipLocationChange:true});
  }

  addUser(): void {
    this.router.navigate(['/ApplicationsUsersAdd',this.appID],{skipLocationChange:true});
  }

  deleteUser(user:Users): void {
    this.router.navigate(['/ApplicationsUsersDelete',user],{skipLocationChange:true});
  }

  openUser(user:Users): void {
    this.router.navigate(['/ApplicationsUsersEdit',user.UserID,this.appID],{skipLocationChange:true});
  }

}
