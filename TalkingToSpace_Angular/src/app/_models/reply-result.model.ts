import { Reply } from "./reply.model";
import { Iresult } from "../_interfaces/iresult";
export class ReplyResult implements Iresult {
    success: boolean;
    backendMessage: string;
    result_set:Reply[]=[];
}
