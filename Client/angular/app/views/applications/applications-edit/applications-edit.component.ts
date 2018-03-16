import { Component, OnInit } from '@angular/core';
import { ParamMap, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ApplicationsService } from '../../../services/client.services';
import { Applications } from '../../../entities/btam-entities';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-applications-edit',
  templateUrl: './applications-edit.component.html',
  styleUrls: ['./applications-edit.component.css']
})
export class ApplicationsEditComponent implements OnInit {

  app:Applications={};

  constructor(private appSvc : ApplicationsService, private route: ActivatedRoute, private location: Location){
  }

  ngOnInit(): void {
    //this.route.paramMap.switchMap((params: ParamMap) => this.appSvc.getApplication(params.get('id'))).subscribe(app => this.app = app);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    alert("Successfully saved!");
  }

}
