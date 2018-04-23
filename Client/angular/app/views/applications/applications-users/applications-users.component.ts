import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApplicationsService } from '../../../services/client.services';
import { Applications,Users } from '../../../entities/btam-entities';

@Component({
  selector: 'app-applications-users',
  templateUrl: './applications-users.component.html',
  styleUrls: ['./applications-users.component.css']
})
export class ApplicationsUsersComponent implements OnInit {

  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private appSvc : ApplicationsService,) { }

  users:Users[]=[];
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

  addUser(): void {
    this.router.navigate(['/ApplicationsUsersAdd'],{skipLocationChange:true});
  }

  deleteUser(user:Users): void {
    this.router.navigate(['/ApplicationsUsersDelete',user],{skipLocationChange:true});
  }

  openUser(user:Users): void {
    this.router.navigate(['/ApplicationsUsersEdit',user.UserID],{skipLocationChange:true});
  }

}
