import { Component,OnInit } from '@angular/core';
import { CompanyProfilesService } from './services/client.services';
import { MyHttpResponse } from './services/httpresponse';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  
  async ngOnInit(){

  }

  constructor(private api : CompanyProfilesService){
    
  }
}
