import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ServiceAttributesService } from '../../../../../../../../services/client.services';
import { ServiceAttributes } from '../../../../../../../../entities/btam-entities';
@Component({
  selector: 'app-attributes-delete',
  templateUrl: './attributes-delete.component.html',
  styleUrls: ['./attributes-delete.component.css']
})
export class AttributesDeleteComponent implements OnInit {
  public appID:string;
  public roleID : string;
  public serviceID:string;
  public attributeID:string;
  public attribute:ServiceAttributes={};
  public attributes:ServiceAttributes[]=[];

  constructor(private router:Router,private activatedroute: ActivatedRoute, 
    private attribSvc : ServiceAttributesService) { }

  ngOnInit() {
    this.roleID = this.activatedroute.snapshot.params['roleID'];
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.serviceID = this.activatedroute.snapshot.params['serviceID'];
    this.attributeID = this.activatedroute.snapshot.params['attributeID'];
    this.attributeID!=null?this.getServices():null;
    
  }

  async getServices(){
    this.attributes =<ServiceAttributes[]> await this.attribSvc.getAttributes(this.serviceID);
    this.attribute = <ServiceAttributes> await this.attributes.find(x=>x.ServiceAttributeID==this.attributeID);
  }

  goBack(): void {
    this.router.navigate(['/ServicesEdit',this.roleID, this.appID,this.serviceID]);
  }

  async delete() {
    var attribute:ServiceAttributes =await this.attribSvc.deleteAttributes(this.attribute.ServiceAttributeID)
    console.log(this.attribute.ServiceAttributeID)
    attribute.ServiceAttributeID==this.attribute.ServiceAttributeID 
    ?(
      alert("Successfully deleted!"),
      await this.goBack()
    ):null;
  }

}
