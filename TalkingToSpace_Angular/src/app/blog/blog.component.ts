import { Component, OnInit } from '@angular/core';import { UserService} from '../_services/user.service'
import {User} from '../_models/user.model'
import { UserResult } from '../_models/user-result.model';
import {Message} from '../_models/message.model'
import { MessageResult } from '../_models/message-result.model';
import {Reply} from '../_models/reply.model'
import { ReplyResult } from '../_models/reply-result.model';
import { MessageService } from '../_services/message.service';
import { ReplyService } from '../_services/reply.service';
import {  Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  reply_available:number;
  update_reply_available1:number;
  update_reply_available2:number;
  user_reply_content:string;

  currentMessage: Message = new Message();
  messages: MessageResult = new MessageResult();
  messageList: Message[];
  messageListSorted: Message[];

  currentReply: Reply = new Reply();
  replys: ReplyResult = new ReplyResult();
  replyList: Reply[];

  constructor(private MessageService: MessageService, private ReplyService: ReplyService, private route: Router, public auth: AuthService) {
    this.reply_available=0;
    this.update_reply_available1=0;
    this.update_reply_available2=0;
    this.user_reply_content="";
  }

  async ngOnInit(): Promise<void> {
    //GET TH GRADES ON LOAD
   this.updateView();

  }

  async addReply(message_id:number, message_content:string) {
    let result = new ReplyResult();
    this.currentReply.message_id=message_id;
    this.currentReply.reply_status='private';
    this.currentReply.reply_content=message_content;
    this.currentReply.user_id=2;
    await this.ReplyService
      .addReply(this.currentReply)
      .then(
        (data) => {
        result.success = data.success;
        result.backendMessage = data.userMessage;
        if (result.success) {
          alert('Comment Successfully Added!');
          this.updateView();
        } else {
          alert(result.backendMessage);
        }
        //this.currentUser = new User();
      }
      )
      .catch((error) => {
        alert(
          error.error.backendMessage +
            ' Please make sure you have provided all the values'
        );
      });
  }

  async updateReply(message_id:number,reply_id:number,message_content:string) {
    let result = new ReplyResult();
    this.currentReply.reply_id=reply_id;
    this.currentReply.message_id=message_id;
    this.currentReply.reply_status='private';
    this.currentReply.reply_content=message_content;
    this.currentReply.user_id=2;
    await this.ReplyService
      .updateReply(this.currentReply)
      .then(
        (data) => {
        result.success = data.success;
        result.backendMessage = data.userMessage;
        if (result.success) {
          alert('Updated Successfully!');
          this.updateView();
        } else {
          alert(result.backendMessage);
        }
        //this.currentUser = new User();
      }
      )
      .catch((error) => {
        alert(
          error.error.backendMessage +
            ' Please make sure you have provided all the values'
        );
      });
  }

  async deleteReply(message_id:number,reply_id:number) {
    let result = new ReplyResult();
    this.currentReply.reply_id=reply_id;
    this.currentReply.message_id=message_id;
    this.currentReply.reply_status='private';
    this.currentReply.reply_content='';
    this.currentReply.user_id=2;
    await this.ReplyService
      .deleteReply(this.currentReply)
      .then(
        (data) => {
        result.success = data.success;
        result.backendMessage = data.userMessage;
        if (result.success) {
          alert('Deleted Successfully!');
          this.updateView();
        } else {
          alert(result.backendMessage);
        }
        //this.currentUser = new User();
      }
      )
      .catch((error) => {
        alert(
          error.error.backendMessage +
            ' Please make sure you have provided all the values'
        );
      });
  }

  public ToggleComment = (value:number) => {
    this.reply_available=value;
  }
  public ToggleUpdateComment = (value1:number,value2:number) => {
    this.update_reply_available1=value1;
    this.update_reply_available2=value2;
  }

  async updateView(): Promise<void> {

    this.messages.result_set = [];
    var t = await this.MessageService
      .getAllMessages()
      .then((message_data) => {

        if (message_data.success) {

          this.messages = message_data;
          this.messageList = message_data.result_set;


        } else {
          alert(message_data.backendMessage);
        }
      })
      .catch((error) => {
        alert(error);
      });


      this.replys.result_set = [];

      var x = await this.ReplyService
      .getAllReplys()
      .then((replydata) => {

        if (replydata.success) {

          this.replys = replydata;
          this.replyList = replydata.result_set;
        } else {
          alert(replydata.backendMessage);
        }
      })
      .catch((error) => {
        alert(error);
      });


  }
}
