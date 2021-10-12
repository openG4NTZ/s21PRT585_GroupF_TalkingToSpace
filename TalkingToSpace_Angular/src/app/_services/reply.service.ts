import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Reply } from '../_models/reply.model';
import { ReplyResult } from '../_models/reply-result.model';
const API_URL = 'http://localhost:53980/api/Reply/';

@Injectable({
  providedIn: 'root'
})
export class ReplyService {


  constructor(private http: HttpClient) { }

  async getAllReplys(): Promise<ReplyResult> {
    return await this.http.get<ReplyResult>(API_URL + 'GetAllReplys').toPromise();
  }

  async addReply(reply: Reply): Promise<any> {
    return await this.http.post<any>(API_URL + 'AddReply', reply,{}).toPromise();;
  }

  async updateReply(reply: Reply): Promise<any> {
    return await this.http.post<any>(API_URL + 'UpdateReply', reply,{}).toPromise();;
  }

  async  deleteReply(reply: Reply): Promise<any> {
    return await this.http.post<any>(API_URL + 'DeleteReply', reply,{}).toPromise();;
  }

}
