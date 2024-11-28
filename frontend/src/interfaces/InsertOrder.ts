import { InsertItemOrder } from "./InsertItemOrder";

export interface InsertOrder {
    from: string,
    orderStatus: string,
    orderDate: Date,
    orderArrivalDate: Date,
    itemOrders: Array<InsertItemOrder>
}