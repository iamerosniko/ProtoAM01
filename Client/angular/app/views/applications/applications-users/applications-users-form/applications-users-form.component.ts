import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from '../../../../services/client.services';
import { Applications,Users } from '../../../../entities/btam-entities';

@Component({
  selector: 'app-applications-users-form',
  templateUrl: './applications-users-form.component.html',
  styleUrls: ['./applications-users-form.component.css']
})
export class ApplicationsUsersFormComponent implements OnInit {

  constructor(private router:Router,private activatedroute: ActivatedRoute, private usrSvc : UsersService
  ) { }

  //public variables
  public FormLabelState:string;
  public user:Users={};
  private userID : string;
  public app:Applications={};

  ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.userID = this.activatedroute.snapshot.params['id'];
    this.userID!=null? this.getUser():null;
  }

  async getUser(){
    //this.user =<Users> await this.usrSvc.getUser(this.userID);
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsUsers', this.app.AppID],{skipLocationChange:true});
  }

}
