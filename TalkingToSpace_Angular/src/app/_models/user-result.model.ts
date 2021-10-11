import { User } from "./user.model";
import { Iresult } from "../_interfaces/iresult";

export class UserResult implements Iresult {
    success: boolean;
    userMessage: string;
    result_set:User[]=[];
}
