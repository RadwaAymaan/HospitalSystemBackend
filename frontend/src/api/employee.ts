import { IEmployee, IEmployeeList, IUpdateEmployee } from 'interfaces/IEmployee';
import fetchApi from './baseFetch';
import { baseUrl } from './utils';

const Url = `${baseUrl}/Employee`;

/**
 * Retrieves a list of employees from the API.
 * @returns A promise resolving to an array of employee objects.
 */
export async function GetEmployee(): Promise<IEmployeeList[]> {
  const data = await fetchApi<IEmployeeList>(Url, "GET");
  let employees = data.value;
  return employees;
}

/**
 * Adds a new employee to the database.
 * @param BodyData - The employee data to be added.
 * @returns A promise resolving to a success message upon successful addition.
 */
export async function AddEmployee(BodyData: IEmployee): Promise<string> {
  const data = await fetchApi<any>(Url, "POST", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Updates an existing employee's information.
 * @param BodyData - The updated employee data.
 * @param id - The ID of the employee to be updated.
 * @returns A promise resolving to a success message upon successful update.
 */
export async function UpdateEmployee(BodyData: IUpdateEmployee, id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}/${id}`, "PUT", JSON.stringify(BodyData));
  return data.successMessage;
}

/**
 * Retrieves an employee's information by ID.
 * @param id - The ID of the employee to retrieve.
 * @returns A promise resolving to an employee object.
 */
export async function GetByIdEmployee(id: string): Promise<IEmployeeList> {
  const data = await fetchApi<any>(`${Url}/${id}`, "GET");
  let employees = data.value;
  return employees;
}

/**
 * Deletes an employee from the database by ID.
 * @param id - The ID of the employee to delete.
 * @returns A promise resolving to a success message upon successful deletion.
 */
export async function DeleteEmployee(id: string): Promise<string> {
  const data = await fetchApi<any>(`${Url}?id=${id}`, "DELETE");
  return data.successMessage;
}
