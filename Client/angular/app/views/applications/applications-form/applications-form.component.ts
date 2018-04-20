import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Applications } from '../../../entities/btam-entities'
@Component({
  selector: 'app-applications-form',
  templateUrl: './applications-form.component.html',
  styleUrls: ['./applications-form.component.css']
})
export class ApplicationsFormComponent implements OnInit {
  constructor(private router:Router,private activatedroute: ActivatedRoute) { }

  //public variables
  public FormLabelState:string;
  public app:Applications
  //private variables

  ngOnInit() {
    this.router.url.includes("Add") ? this.FormLabelState ="New" : this.FormLabelState = "Edit";
    
    this.activatedroute.params.subscribe(params => this.app = params);
    console.log(this.app);
  }

  goBack(): void {
    this.router.navigate(['/Applications'],{skipLocationChange:true});
  }

  save(): void {
    console.log(this.app.AppID==null);
    alert("Successfully saved!");
  }
}
