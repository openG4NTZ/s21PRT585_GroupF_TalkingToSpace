import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Student } from '../student';

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrls: ['./tournament.component.css']
})
export class TournamentComponent implements OnInit {

  studentdsJson: Array<Student> = new Array<Student>();
  copyStudentdsJson: Array<Student> = new Array<Student>();
  showBool: boolean;
  str: string = "";
  aboveFifty = (x: Student): boolean => { return x.grade >= 50 };
  underFifty = (x: Student): boolean => { return x.grade < 50 };
  grade100 = (x: Student): boolean => { return x.grade == 100 };
  searchStr = (x: Student): boolean => {
     return x.name.toLowerCase().indexOf(this.strSearch, 0) != -1

     };

  strSearch: string;

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
  }

  initialize() {
    for (let i: number = 0; i < this.studentdsJson.length; i++) {
      this.copyStudentdsJson[i] = new Student();
      Object.assign(this.copyStudentdsJson[i], this.studentdsJson[i]);
    }
  }

  showList() {
    this.initialize();
    this.showBool = true;
  }

  searchFunc(str:string) {
    this.initialize();
    this.strSearch = str;
    this.filterResults(this.searchStr);

  }


  filterResults(funcParam: any) {
    this.showBool = true;
    this.copyStudentdsJson = this.studentdsJson.filter(funcParam);
  }


}
