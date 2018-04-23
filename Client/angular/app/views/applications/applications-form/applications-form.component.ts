import { Component, OnInit  } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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
    private appSvc : ApplicationsService,) { }

  //public variables
  public FormLabelState:string;
  public app:Applications={};
  private appID : string;
  //private variables
    private sub : any;
  ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.appID = this.activatedroute.snapshot.params['id'];
    this.appID!=null? this.getApplication():null;
  }

  async getApplication(){
    
    this.app =<Applications> await this.appSvc.getApplication(this.appID);
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
