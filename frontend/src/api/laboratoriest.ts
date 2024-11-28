import { ILaboratoriest, ILaboratoriestList } from 'interfaces/Laboratoriest';
import fetchApi from './baseFetch';
import { baseUrl } from './utils';


const Url = `${baseUrl}/Laboratoriest`;

/**
 * Retrieves a list of Laboratoriests from the API.
 * @returns A promise resolving to an array of Laboratoriest objects.
 */
export async function getLaboratoriest(): Promise<ILaboratoriestList[]> {
  const data = await fetchApi<any>(Url, "GET");
  let Laboratoriests = data.value;
  return Laboratoriests;
}

/**
 * Adds a new Laboratoriest to the database.
 * @param BodyData - The Laboratoriest data to be added.
 * @returns A promise resolving to a success message upon successful addition.
 */
export async function addLaboratoriest(BodyData: ILaboratoriest): Promise<string> {
  const data = await fetchApi<any>(Url, "POST", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Updates an existing Laboratoriest's information.
 * @param BodyData - The updated Laboratoriest data.
 * @param id - The ID of the Laboratoriest to be updated.
 * @returns A promise resolving to a success message upon successful update.
 */
export async function updateLaboratoriest(BodyData: ILaboratoriest, id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}/${id}`, "PUT", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Retrieves an Laboratoriest's information by ID.
 * @param id - The ID of the Laboratoriest to retrieve.
 * @returns A promise resolving to an Laboratoriest object.
 */
export async function getByIdLaboratoriest(id: string): Promise<ILaboratoriestList> {
  const data = await fetchApi<any>(`${Url}/${id}`, "GET");
  let Laboratoriests = data.value;
  return Laboratoriests;
}

/**
 * Deletes an Laboratoriest from the database by ID.
 * @param id - The ID of the Laboratoriest to delete.
 * @returns A promise resolving to a success message upon successful deletion.
 */
export async function deleteLaboratoriest(id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}?id=${id}`, "DELETE");
  return data.successMessage;
}
