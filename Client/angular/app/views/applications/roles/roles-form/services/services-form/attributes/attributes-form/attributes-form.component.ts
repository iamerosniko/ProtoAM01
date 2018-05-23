import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ServiceAttributesService } from '../../../../../../../../services/client.services';
import { ServiceAttributes } from '../../../../../../../../entities/btam-entities';
@Component({
  selector: 'app-attributes-form',
  templateUrl: './attributes-form.component.html',
  styleUrls: ['./attributes-form.component.css']
})
export class AttributesFormComponent implements OnInit {
  public appID:string;
  public roleID : string;
  public serviceID:string;
  public attributeID:string;
  public FormLabelState:string;
  public attribute:ServiceAttributes={};
  public attributes:ServiceAttributes[]=[];
  attributeForm=new FormGroup({

  });
  constructor(private router:Router,private activatedroute: ActivatedRoute, 
    private attribSvc : ServiceAttributesService,private fb:FormBuilder) { }


  ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    
    this.roleID = this.activatedroute.snapshot.params['roleID'];
    this.appID = this.activatedroute.snapshot.params['appID'];
    this.serviceID = this.activatedroute.snapshot.params['serviceID'];
    this.attributeID = this.activatedroute.snapshot.params['attributeID'];
    this.attributeID!=null?this.getServices():null;

    this.attributeForm = this.fb.group({
      ServiceID:[this.serviceID],
      AttribName:[this.attribute.AttribName,Validators.required],
      AttribDesc:[this.attribute.AttribDesc],
    })
    console.log(this.attributeForm.value)
    
  }

  async getServices(){
    this.attributes =<ServiceAttributes[]> await this.attribSvc.getAttributes(this.serviceID);
    this.attribute = <ServiceAttributes> await this.attributes.find(x=>x.ServiceAttributeID==this.attributeID);

    this.attributeForm = this.fb.group({
      ServiceAttributeID:[this.attribute.ServiceAttributeID],
      ServiceID:[this.attribute.ServiceID],
      AttribName:[this.attribute.AttribName,Validators.required],
      AttribDesc:[this.attribute.AttribDesc],
    })

  }

  goBack(): void {
    this.router.navigate(['/ServicesEdit',this.roleID, this.appID,this.serviceID],{skipLocationChange:true});
  }

  async save(){
    this.attribute=await this.attributeForm.value;
    var attribute:ServiceAttributes ={};
    console.log(this.attribute)
    if(this.attribute.ServiceAttributeID==null){
      attribute = <ServiceAttributes> await this.attribSvc.postAttributes(this.attribute);
    }
    else{
      attribute = <ServiceAttributes> await this.attribSvc.putAttributes(this.attribute);
    }
    if(attribute!=null)
    {
      await alert("Successfully saved!");
      this.goBack();
    }  
  }
}
