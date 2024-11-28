import { IItem } from "./IItem";

export interface IItemOrder {
    id: number;
    quantity: number;
    item: IItem;
}