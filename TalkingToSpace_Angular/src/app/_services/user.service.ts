
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user.model';
import { UserResult } from '../_models/user-result.model';

const API_URL = 'http://localhost:53980/api/User/';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  async getAllUsers(): Promise<UserResult> {
    return await this.http.get<UserResult>(API_URL + 'GetAllUsers').toPromise();
  }

  async addUser(user: User): Promise<any> {
    return await this.http.post<any>(API_URL + 'AddUser', user,{})
    .toPromise();
  }

  updateUser(data:any): Observable<any> {
    return this.http.post(API_URL + 'UpdateUser', { responseType: 'text' });
  }

  deleteUser(data:any): Observable<any> {
    return this.http.post(API_URL + 'DeleteUser', { responseType: 'text' });
  }

}
