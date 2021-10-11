import { Component, OnInit, Inject, Output, EventEmitter } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.css']
})
export class SidenavListComponent implements OnInit {
  @Output() sidenavClose = new EventEmitter();

  public userName: string;
  public totalPoints: number;

  constructor(
    public auth: AuthService,
    @Inject(DOCUMENT) private doc: Document
  ) {


    this.userName="G4NTZ";
    this.totalPoints=999;
  }



  ngOnInit(): void {

  }
  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }
  signup(): void {
    this.auth.loginWithRedirect({ screen_hint: 'signup' });
  }
  login(): void {
    this.auth.loginWithRedirect();
  }
  logout(): void {
    this.auth.logout({ returnTo: document.location.origin });
  }
}
