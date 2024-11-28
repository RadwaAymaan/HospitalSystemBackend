import fetchApi from './baseFetch';
import { baseUrl } from './utils';
import { IInventory, IInventoryList } from 'interfaces/Inventory';

const Url = `${baseUrl}/inventory`;

/**
 * Retrieves a list of inventorys from the API.
 * @returns A promise resolving to an array of inventory objects.
 */
export async function getInventory(): Promise<IInventoryList[]> {
  const data = await fetchApi<any>(Url, "GET");
  let inventorys = data.value;
  return inventorys;
}

/**
 * Adds a new inventory to the database.
 * @param BodyData - The inventory data to be added.
 * @returns A promise resolving to a success message upon successful addition.
 */
export async function addInventory(BodyData: IInventory): Promise<string> {
  const data = await fetchApi<any>(Url, "POST", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Updates an existing inventory's information.
 * @param BodyData - The updated inventory data.
 * @param id - The ID of the inventory to be updated.
 * @returns A promise resolving to a success message upon successful update.
 */
export async function updateInventory(BodyData: IInventory, id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}/${id}`, "PUT", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Retrieves an inventory's information by ID.
 * @param id - The ID of the inventory to retrieve.
 * @returns A promise resolving to an inventory object.
 */
export async function getByIdInventory(id: string): Promise<IInventoryList> {
  const data = await fetchApi<any>(`${Url}/${id}`, "GET");
  let inventorys = data.value;
  return inventorys;
}

/**
 * Deletes an inventory from the database by ID.
 * @param id - The ID of the inventory to delete.
 * @returns A promise resolving to a success message upon successful deletion.
 */
export async function deleteInventory(id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}?id=${id}`, "DELETE");
  return data.successMessage;
}
