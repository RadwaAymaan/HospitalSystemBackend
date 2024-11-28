import { IItemCategory } from "./IItemCategory";

export interface IItem {
    id: number;
	name: string;
	description: string;
	stock: number;
	price: number;
	category: IItemCategory;
}