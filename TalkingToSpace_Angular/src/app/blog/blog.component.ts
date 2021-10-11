import { Component, OnInit,EventEmitter,Output } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})

export class BlogComponent implements OnInit {

  @Output() public test = new EventEmitter();

  profileJson: string;

  constructor(public auth: AuthService) { }


  ngOnInit(): void {

}


public onToggleSidenav = () => {
  this.test.emit();
}

}
