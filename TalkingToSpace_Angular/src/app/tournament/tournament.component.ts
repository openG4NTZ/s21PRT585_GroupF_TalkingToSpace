import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { User } from './user';
import {Point} from '../_models/point.model'
import { PointResult } from '../_models/point-result.model';
import { PointService } from '../_services/point.service';

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrls: ['./tournament.component.css']
})
export class TournamentComponent implements OnInit {


  currentPoint: Point = new Point();
  points: PointResult = new PointResult();
  pointList: Point[];

  copypointList: Array<Point> = new Array<Point>();
  showBool: boolean;
  str: string = "";
  aboveFifty = (x: Point): boolean => { return x.point_amount >= 50 };
  underFifty = (x: Point): boolean => { return x.point_amount < 50 };
  grade100 = (x: Point): boolean => { return x.point_amount == 100 };
  searchStr = (x: Point): boolean => {
     //return x.name.toLowerCase().indexOf(this.strSearch, 0) != -1
     return (x.user_id).toString().toLowerCase().indexOf(this.strSearch, 0) != -1


     };

  strSearch: string;

  constructor(public auth: AuthService, private PointService:PointService) { }

  ngOnInit(): void {
  }

  initialize() {
    for (let i: number = 0; i < this.pointList.length; i++) {
      this.copypointList[i] = new Point();
      Object.assign(this.copypointList[i], this.pointList[i]);
    }
  }

  async showList() {
    await this.updateView();
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
    this.copypointList = this.pointList.filter(funcParam);
  }
  async updateView(): Promise<void> {

    this.points.result_set = [];
    var t = await this.PointService
      .getAllPoints()
      .then((point_data) => {

        if (point_data.success) {
          this.points = point_data;
          this.pointList = point_data.result_set;
        } else {
          alert(point_data.backendMessage);
        }
      })
      .catch((error) => {
        alert(error);
      });
  }

}
