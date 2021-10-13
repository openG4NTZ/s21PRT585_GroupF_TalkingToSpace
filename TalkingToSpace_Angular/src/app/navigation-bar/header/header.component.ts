import { Component, OnInit, Inject, Output, EventEmitter } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Output() public sidenavToggle = new EventEmitter();
  constructor(
    @Inject(DOCUMENT) public document: Document, public auth: AuthService
  ) {


  }

  ngOnInit(): void {
  }

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
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
