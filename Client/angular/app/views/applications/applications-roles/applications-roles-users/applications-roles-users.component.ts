import { Component, OnInit } from '@angular/core';
import { Users,Roles } from '../../../../entities/btam-entities';
import { RolesService, UsersService } from '../../../../services/client.services';

@Component({
  selector: 'app-applications-roles-users',
  templateUrl: './applications-roles-users.component.html',
  styleUrls: ['./applications-roles-users.component.css']
})

export class ApplicationsRolesUsersComponent implements OnInit {

  users:Users[]=[];
  constructor() { }
  
  ngOnInit() {
  }

}
