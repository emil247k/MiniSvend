import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent implements OnInit {

  constructor(public router: Router) {

  }

  ngOnInit(): void {
  }
  public navigate(){
    this.router.navigate(['login'])
  }
}
