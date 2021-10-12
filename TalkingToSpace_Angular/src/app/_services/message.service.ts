import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Message } from '../_models/message.model';
import { MessageResult } from '../_models/message-result.model';
const API_URL = 'http://localhost:53980/api/Message/';

@Injectable({
  providedIn: 'root'
})
export class MessageService {


  constructor(private http: HttpClient) { }

  async getAllMessages(): Promise<MessageResult> {
    return await this.http.get<MessageResult>(API_URL + 'GetAllMessages').toPromise();
  }

  async addMessage(reply: Message): Promise<any> {
    return await this.http.post<any>(API_URL + 'AddMessage', reply,{}).toPromise();;
  }

  async updateMessage(reply: Message): Promise<any> {
    return await this.http.post<any>(API_URL + 'UpdateMessage', reply,{}).toPromise();;
  }

  async  deleteMessage(reply: Message): Promise<any> {
    return await this.http.post<any>(API_URL + 'DeleteeMessage', reply,{}).toPromise();;
  }

}
