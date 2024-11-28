import fetchApi from './baseFetch';
import { baseUrl } from './utils';
import { IRoom, IRoomList } from 'interfaces/IRoom';

const Url = `${baseUrl}/room`;

/**
 * Retrieves a list of rooms from the API.
 * @returns A promise resolving to an array of room objects.
 */
export async function GetRoom(): Promise<IRoomList[]> {
  const data = await fetchApi<any>(Url, "GET");
  let rooms = data.value;
  return rooms;
}

/**
 * Adds a new room to the database.
 * @param BodyData - The room data to be added.
 * @returns A promise resolving to a success message upon successful addition.
 */
export async function AddRoom(BodyData: IRoom): Promise<string> {
  const data = await fetchApi<any>(Url, "POST", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Updates an existing room's information.
 * @param BodyData - The updated room data.
 * @param id - The ID of the room to be updated.
 * @returns A promise resolving to a success message upon successful update.
 */
export async function UpdateRoom(BodyData: IRoom, id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}/${id}`, "PUT", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Retrieves an room's information by ID.
 * @param id - The ID of the room to retrieve.
 * @returns A promise resolving to an room object.
 */
export async function GetByIdRoom(id: string): Promise<IRoomList> {
  const data = await fetchApi<any>(`${Url}/${id}`, "GET");
  let rooms = data.value;
  return rooms;
}

/**
 * Deletes an room from the database by ID.
 * @param id - The ID of the room to delete.
 * @returns A promise resolving to a success message upon successful deletion.
 */
export async function DeleteRoom(id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}?id=${id}`, "DELETE");
  return data.successMessage;
}
