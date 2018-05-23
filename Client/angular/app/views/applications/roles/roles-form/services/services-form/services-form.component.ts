import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ServicesService } from '../../../../../../services/client.services';
import { Services } from '../../../../../../entities/btam-entities';

@Component({
  selector: 'app-services-form',
  templateUrl: './services-form.component.html',
  styleUrls: ['./services-form.component.css']
})
export class ServicesFormComponent implements OnInit {
  public appID:string;
  public roleID : string;
  public serviceID:string;
  public FormLabelState:string;
  public service:Services={};
  public services:Services[]=[];
  serviceForm=new FormGroup({

  });

  constructor(private router:Router,private activatedroute: ActivatedRoute, 
    private serviceSvc : ServicesService,private fb:FormBuilder) { }

  async ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    this.roleID = this.activatedroute.snapshot.params['roleID'];
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.serviceID = this.activatedroute.snapshot.params['serviceID'];

    this.serviceID!=null?this.getServices():null;

    this.serviceForm = this.fb.group({
      ServiceName:[this.service.ServiceName,Validators.required],
      ServiceDesc:[this.service.ServiceDesc],
    })
  }

  async getServices(){
    
    this.services =<Services[]> await this.serviceSvc.getService(this.roleID);
    this.service = <Services> await this.services.find(x=>x.ServiceID==this.serviceID);

    this.serviceForm = this.fb.group({
      ServiceID:[this.service.ServiceID],
      ServiceName:[this.service.ServiceName,Validators.required],
      ServiceDesc:[this.service.ServiceDesc],
    })
  }

  async save() {
    this.service=await this.serviceForm.value;
    var service:Services ={};
    if(this.service.ServiceID==null){
      service = <Services> await this.serviceSvc.postService(this.roleID,this.service);
    }
    else{
      service = <Services> await this.serviceSvc.putService(this.service);
    }
    if(service!=null)
    {
      await alert("Successfully saved!");
      this.goBack();
    }  
  }
  goBack(): void {
    this.router.navigate(['/ApplicationsRolesEdit',this.roleID, this.appID],{skipLocationChange:true});
  }
  gotoAttributes():void{
    this.router.navigate(['/AttributesAdd',this.roleID, this.appID,this.serviceID],{skipLocationChange:true});
  }
}
