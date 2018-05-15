import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ServicesService } from '../../../../../services/client.services';
import { Services } from '../../../../../entities/btam-entities';
@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  services:Services[]=[];
  roleID:string;

  constructor(private serviceSvc : ServicesService, private router:Router,
    private activatedroute: ActivatedRoute) { }

  async ngOnInit() {
    this.roleID =await this.activatedroute.snapshot.params['roleID'];
    await this.getDependencies();
  }

  async getDependencies(){
    console.log(this.roleID)
    
    this.services = <Services[]> await this.serviceSvc.getService(this.roleID);
    console.log(this.services);
  }
}
