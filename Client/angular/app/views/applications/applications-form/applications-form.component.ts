import { Component, OnInit  } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { UUID } from 'angular2-uuid';
import { Router, ActivatedRoute } from '@angular/router';
import { ApplicationsService } from '../../../services/client.services';
import { Applications } from '../../../entities/btam-entities'
@Component({
  selector: 'app-applications-form',
  templateUrl: './applications-form.component.html',
  styleUrls: ['./applications-form.component.css']
})
export class ApplicationsFormComponent implements OnInit {
  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private appSvc : ApplicationsService,private fb:FormBuilder) 
  {

  }

  //public variables
  public FormLabelState:string;
  appForm = new FormGroup({
  });
  public app:Applications={};
  private appID : string;
  //private variables
    private sub : any;
  ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.appID = this.activatedroute.snapshot.params['id'];
    this.appID!=null
    ? this.getApplication()
    :null;

    this.appForm = this.fb.group({
      AppName : [this.app.AppName,Validators.required],
      AppMemberName : [this.app.AppMemberName,Validators.required],
      AppSecurityKey : [UUID.UUID(),Validators.required],
      AppUrl : [this.app.AppUrl,Validators.required],
    });
  }

  async getApplication(){
    this.app = <Applications> await this.appSvc.getApplication(this.appID);
    this.appForm = this.fb.group({
      AppID:[this.app.AppID,Validators.required],
      AppName : [this.app.AppName,Validators.required],
      AppMemberName : [this.app.AppMemberName,Validators.required],
      AppSecurityKey : [this.app.AppSecurityKey,Validators.required],
      AppUrl : [this.app.AppUrl,Validators.required],
    })
  }

  goBack(): void {
    this.router.navigate(['/Applications'],{skipLocationChange:true});
  }

  getRoles(app:Applications): void {
    this.router.navigate(['/ApplicationsRoles',app.AppID],{skipLocationChange:true});
  }

  getUsers(app:Applications): void {
    this.router.navigate(['/ApplicationsUsers',app.AppID],{skipLocationChange:true});
  }

  async save() {
    this.app=await this.appForm.value;
    var app:Applications ={};
    if(this.app.AppID==null){
      app = <Applications> await this.appSvc.postApplication(this.app);
    }
    else{
      app = <Applications> await this.appSvc.putApplication(this.app);
    }
    if(app!=null)
    {
      await alert("Successfully saved!");
      this.goBack();
    }  
  }

}
