import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ServiceAttributesService } from '../../../../../../../services/client.services';
import { ServiceAttributes } from '../../../../../../../entities/btam-entities';
@Component({
  selector: 'app-attributes',
  templateUrl: './attributes.component.html',
  styleUrls: ['./attributes.component.css']
})
export class AttributesComponent implements OnInit {
  public appID:string;
  public roleID : string;
  public serviceID:string;
  attributes:ServiceAttributes[]=[];

  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private attrSvc:ServiceAttributesService) { }

  async ngOnInit() {
    this.roleID = this.activatedroute.snapshot.params['roleID'];
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.serviceID = this.activatedroute.snapshot.params['serviceID'];
    
    this.attributes=<ServiceAttributes[]>await this.attrSvc.getAttributes(this.serviceID);
    console.log(this.attributes)
  }

  openAttribute(attr:ServiceAttributes){
    console.log(attr.ServiceAttributeID)
    this.router.navigate(['/AttributesEdit',this.roleID, this.appID,this.serviceID,attr.ServiceAttributeID]);

  }

  deleteAttribute(attr:ServiceAttributes){
    this.router.navigate(['/AttributesDelete',this.roleID, this.appID,this.serviceID,attr.ServiceAttributeID]);
  }
}
