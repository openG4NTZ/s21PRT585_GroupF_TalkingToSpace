import { Iresult } from "../_interfaces/iresult"
import { Message } from "./message.model";

export class MessageResult implements Iresult {
    success: boolean;
    backendMessage: string;
    result_set: Message[] = [];
}
