import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';

import { ApplicationsService } from '../../../services/client.services';
import { Applications } from '../../../entities/btam-entities';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-applications-delete',
  templateUrl: './applications-delete.component.html',
  styleUrls: ['./applications-delete.component.css']
})
export class ApplicationsDeleteComponent implements OnInit {

  app:Applications={};
  
  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private appSvc : ApplicationsService){
  }

  ngOnInit(): void {
    this.activatedroute.params.subscribe(params => this.app = params);
  }

  goBack(): void {
    this.router.navigate(['/Applications'],{skipLocationChange:true});
  }

  async delete() {
    var app:Applications =await this.appSvc.deleteApplication(this.app.AppID.toString())
    console.log(this.app.AppID)
    app.AppID==this.app.AppID 
    ?(
      alert("Successfully deleted!"),
      await this.goBack()
    ):null;
  }
}
