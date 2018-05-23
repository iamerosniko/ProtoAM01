import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';

import { UsersService } from '../../../../services/client.services';
import { Users } from '../../../../entities/btam-entities';

@Component({
  selector: 'app-applications-users-delete',
  templateUrl: './users-delete.component.html',
  styleUrls: ['./users-delete.component.css']
})
export class ApplicationsUsersDeleteComponent implements OnInit {

  private appID:string;
  user:Users={};

  constructor(private router:Router,private activatedroute: ActivatedRoute,
    private userSvc : UsersService) { }

  ngOnInit() {
    this.activatedroute.params.subscribe(params => this.user = params);
    this.appID = this.activatedroute.snapshot.params['appID'];
  }

  goBack(): void {
    this.router.navigate(['/ApplicationsUsers', this.appID],{skipLocationChange:true});
  }

  async delete() {
    var user:Users =await this.userSvc.deleteUser(this.user.UserID.toString())
    user!=null
    ?(
      alert("Successfully saved!"),
      await this.goBack()
    ):null;
  }
}
