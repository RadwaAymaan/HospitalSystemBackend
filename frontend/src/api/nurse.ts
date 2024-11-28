import { INurse, INurseList } from 'interfaces/Nurse';
import fetchApi from './baseFetch';
import { baseUrl } from './utils';


const Url = `${baseUrl}/Nurse`;

/**
 * Retrieves a list of Nurses from the API.
 * @returns A promise resolving to an array of nurse objects.
 */
export async function getNurse(): Promise<INurseList[]> {
  const data = await fetchApi<any>(Url, "GET");
  let Nurses = data.value;
  return Nurses;
}

/**
 * Adds a new Nurse to the database.
 * @param BodyData - The nurse data to be added.
 * @returns A promise resolving to a success message upon successful addition.
 */
export async function addNurse(BodyData: INurse): Promise<string> {
  const data = await fetchApi<any>(Url, "POST", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Updates an existing nurse's information.
 * @param BodyData - The updated Nurse data.
 * @param id - The ID of the nurse to be updated.
 * @returns A promise resolving to a success message upon successful update.
 */
export async function updateNurse(BodyData: INurse, id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}/${id}`, "PUT", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Retrieves an nurse's information by ID.
 * @param id - The ID of the Nurse to retrieve.
 * @returns A promise resolving to an Nurse object.
 */
export async function getByIdNurse(id: string): Promise<INurseList> {
  const data = await fetchApi<any>(`${Url}/${id}`, "GET");
  let Nurses = data.value;
  return Nurses;
}

/**
 * Deletes an nurse from the database by ID.
 * @param id - The ID of the nurse to delete.
 * @returns A promise resolving to a success message upon successful deletion.
 */
export async function deleteNurse(id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}?id=${id}`, "DELETE");
  return data.successMessage;
}
