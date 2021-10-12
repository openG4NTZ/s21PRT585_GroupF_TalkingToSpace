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
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  reply_available:number;
  update_reply_available:number;
  user_message_content:string;

  currentMessage: Message = new Message();
  messages: MessageResult = new MessageResult();
  messageList: Message[];

  currentReply: Reply = new Reply();
  replys: ReplyResult = new ReplyResult();
  replyList: Reply[];

  constructor(private MessageService: MessageService, private ReplyService: ReplyService, private route: Router, public auth: AuthService) {
    this.reply_available=0;
    this.update_reply_available=0;
    this.user_message_content="";
  }

  async ngOnInit(): Promise<void> {
    //GET TH GRADES ON LOAD
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

  async addMessage(message_content:string) {
    let result = new MessageResult();
    this.currentMessage.message_content=message_content;
    this.currentMessage.message_status='private';
    this.currentMessage.message_modified_date=new Date();
    this.currentMessage.message_sent_date=new Date();
    this.currentMessage.user_id=2;

    console.warn(this.currentMessage);
    await this.MessageService
      .addMessage(this.currentMessage)
      .then(
        (updatedata) => {
        result.success = updatedata.success;
        result.backendMessage = updatedata.u;
        if (result.success) {
          alert('Updated Successfully!');
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

  async updateMessage(message_id:number, message_content:string) {
    let result = new MessageResult();
    this.currentMessage.message_id=message_id;
    this.currentMessage.message_content=message_content;
    this.currentMessage.message_status='private';
    this.currentMessage.message_modified_date=new Date();
    this.currentMessage.message_sent_date=new Date();
    this.currentMessage.user_id=2;

    console.warn(this.currentMessage);
    await this.MessageService
      .updateMessage(this.currentMessage)
      .then(
        (updatedata) => {
        result.success = updatedata.success;
        result.backendMessage = updatedata.u;
        if (result.success) {
          alert('Updated Successfully!');
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

  async deleteMessage(message_id:number) {
    let result = new MessageResult();

    this.currentMessage.message_id=message_id;
    this.currentMessage.user_id=2;
    await this.MessageService
      .deleteMessage(this.currentMessage)
      .then(
        (data) => {
        result.success = data.success;
        result.backendMessage = data.userMessage;
        if (result.success) {
          alert('Deleted Successfully!');
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
  public ToggleUpdateComment = (value:number) => {
    this.update_reply_available=value;
  }

}
