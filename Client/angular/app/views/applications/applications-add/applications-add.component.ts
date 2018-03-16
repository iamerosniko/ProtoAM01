import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-applications-add',
  templateUrl: './applications-add.component.html',
  styleUrls: ['./applications-add.component.css']
})
export class ApplicationsAddComponent implements OnInit {

  constructor(private location: Location) { }

  ngOnInit() {
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    alert("Successfully saved!");
  }
}
