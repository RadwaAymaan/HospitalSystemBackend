import { IItemCategory } from "./IItemCategory";
export interface IInventoryList {
	id: number,
	inventoryName: string,
	inventoryLocation: string,
	inventoryCapacity: number,
	categories: IItemCategory[]

}

export interface IInventory {
	inventoryName: string,
	inventoryLocation: string,
	inventoryCapacity: number,

}