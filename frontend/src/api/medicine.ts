
import { IMedicine, IMedicineList } from 'interfaces/Medicine';
import fetchApi from './baseFetch';
import { baseUrl } from './utils';


const Url = `${baseUrl}/Medicine`;

/**
 * Retrieves a list of Medicines from the API.
 * @returns A promise resolving to an array of Medicine objects.
 */
export async function getMedicine(): Promise<IMedicineList[]> {
  const data = await fetchApi<any>(Url, "GET");
  let medicines = data.value;
  return medicines;
}

/**
 * Adds a new Medicine to the database.
 * @param BodyData - The Medicine data to be added.
 * @returns A promise resolving to a success message upon successful addition.
 */
export async function addMedicine(BodyData: IMedicine): Promise<string> {
  const data = await fetchApi<any>(Url, "POST", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Updates an existing Medicine's information.
 * @param BodyData - The updated medicine data.
 * @param id - The ID of the Medicine to be updated.
 * @returns A promise resolving to a success message upon successful update.
 */
export async function updateMedicine(BodyData: IMedicine, id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}/${id}`, "PUT", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Retrieves an medicine's information by ID.
 * @param id - The ID of the medicine to retrieve.
 * @returns A promise resolving to an medicine object.
 */
export async function getByIdMedicine(id: string): Promise<IMedicineList> {
  const data = await fetchApi<any>(`${Url}/${id}`, "GET");
  let Medicines = data.value;
  return Medicines;
}

/**
 * Deletes an medicine from the database by ID.
 * @param id - The ID of the medicine to delete.
 * @returns A promise resolving to a success message upon successful deletion.
 */
export async function deleteMedicine(id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}?id=${id}`, "DELETE");
  return data.successMessage;
}
