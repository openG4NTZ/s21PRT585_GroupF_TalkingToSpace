import { User } from "./user.model";
import { Iresult } from "../_interfaces/iresult";

export class UserResult implements Iresult {
    success: boolean;
    backendMessage: string;
    result_set:User[]=[];
}
