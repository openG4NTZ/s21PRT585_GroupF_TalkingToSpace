import { User } from "./user.model";
export class Reply {
    reply_id:number;
    reply_content: string;
    reply_status: string;
    reply_sent_date: Date;
    user_id: number;
    message_id:number;

    // user:User = new User();
}
