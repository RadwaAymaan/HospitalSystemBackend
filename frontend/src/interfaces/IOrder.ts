import { IItemOrder } from "./IItemOrder";

export interface IOrder {
    id: number;
    from: string;
    orderStatus: string;
    orderDate: Date;
    orderArrivalDate: Date;
    itemOrders: Array<IItemOrder>
}