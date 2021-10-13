import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.css']
})
export class SidenavListComponent implements OnInit {
  @Output() sidenavClose = new EventEmitter();

  public userName: string;
  public totalPoints: number;
  constructor() {
    this.userName="G4NTZ";
    this.totalPoints=999; }

  ngOnInit(): void {
    
  }
  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }
}
