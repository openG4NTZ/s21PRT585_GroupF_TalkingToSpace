import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Point } from '../_models/point.model';
import { PointResult } from '../_models/point-result.model';
const API_URL = 'http://localhost:53980/api/Point/';

@Injectable({
  providedIn: 'root'
})
export class PointService {

  constructor(private http: HttpClient) { }

  async getAllPoints(): Promise<PointResult> {
    return await this.http.get<PointResult>(API_URL + 'GetAllPoints').toPromise();
  }

  async addPoint(point: Point): Promise<any> {
    return await this.http.post<any>(API_URL + 'AddPoint', point,{}).toPromise();;
  }

  async updatePoint(point: Point): Promise<any> {
    return await this.http.post<any>(API_URL + 'UpdatePoint', point,{}).toPromise();;
  }

  async  deletePoint(point: Point): Promise<any> {
    return await this.http.post<any>(API_URL + 'DeletePoint', point,{}).toPromise();;
  }
}
