import { Iresult } from "../_interfaces/iresult"
import { Point } from "./point.model";

export class PointResult implements Iresult {
    success: boolean;
    backendMessage: string;
    result_set: Point[] = [];
}
