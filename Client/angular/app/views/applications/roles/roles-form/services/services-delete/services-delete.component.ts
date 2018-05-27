import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ServicesService } from '../../../../../../services/client.services';
import { Services } from '../../../../../../entities/btam-entities';

@Component({
  selector: 'app-services-delete',
  templateUrl: './services-delete.component.html',
  styleUrls: ['./services-delete.component.css']
})
export class ServicesDeleteComponent implements OnInit {
  public appID:string;
  public roleID : string;
  public serviceID:string;
  public service:Services={};
  public services:Services[]=[];

  constructor(private router:Router,private activatedroute: ActivatedRoute, 
    private serviceSvc : ServicesService) { }

  ngOnInit() {
    this.roleID = this.activatedroute.snapshot.params['roleID'];
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.serviceID = this.activatedroute.snapshot.params['serviceID'];

    this.serviceID!=null?this.getServices():null;
  }

  async getServices(){
    this.services =<Services[]> await this.serviceSvc.getService(this.roleID);
    this.service = <Services> await this.services.find(x=>x.RoleServiceID==this.serviceID);
  }


  goBack(): void {
    this.router.navigate(['/ApplicationsRolesEdit',this.roleID, this.appID],{skipLocationChange:true});
  }

  async delete() {
    var service:Services =await this.serviceSvc.deleteService(this.service.RoleServiceID.toString())
    console.log(this.service.RoleServiceID)
    service.RoleServiceID==this.service.RoleServiceID 
    ?(
      alert("Successfully deleted!"),
      await this.goBack()
    ):null;
  }
}
