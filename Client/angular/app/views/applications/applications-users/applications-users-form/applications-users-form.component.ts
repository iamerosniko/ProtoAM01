import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from '../../../../services/client.services';
import { Users } from '../../../../entities/btam-entities';

@Component({
  selector: 'app-applications-users-form',
  templateUrl: './applications-users-form.component.html',
  styleUrls: ['./applications-users-form.component.css']
})
export class ApplicationsUsersFormComponent implements OnInit {

  constructor(private router:Router,private activatedroute: ActivatedRoute, 
    private usrSvc : UsersService,private fb:FormBuilder
  ) { }

  //public variables
  public FormLabelState:string;
  public user:Users={};
  userForm = new FormGroup({
  });
  private users:Users[]=[];
  private userID : string;
  private appID:string;
  

  ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.userID = this.activatedroute.snapshot.params['userID'];
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.userID!=null? this.getUser():null;

    this.userForm = this.fb.group({
      UserName : [this.user.UserName,Validators.required],
      FirstName : [this.user.FirstName,Validators.required],
      LastName : [this.user.LastName,Validators.required],
    });
  }

  async getUser(){
    this.users =<Users[]> await this.usrSvc.getUsers(this.appID);    
    this.user = <Users> await this.users.find(x=>x.UserID == this.userID);
  
    this.userForm = this.fb.group({
      UserID:[this.user.UserID,Validators.required],
      UserName : [this.user.UserName,Validators.required],
      FirstName : [this.user.FirstName,Validators.required],
      LastName : [this.user.LastName,Validators.required],

    });
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsUsers', this.appID],{skipLocationChange:true});
  }

  async save() {
    this.user=await this.userForm.value;
    var user:Users ={};
    if(this.user.UserID==null){
      user = <Users> await this.usrSvc.postUser(this.appID,this.user);
    }
    else{
      user = <Users> await this.usrSvc.putUser(this.userID,this.user);
    }
    if(user!=null)
    {
      await alert("Successfully saved!");
      this.goBack();
    }  
  }
}
