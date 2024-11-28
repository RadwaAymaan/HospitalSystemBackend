import { IPatient, IPatientList, IUpdatePatient } from "interfaces/IPatient";
import token from "./token";
import header from "./utils";
import fetchApi from "./baseFetch";
let patients :IPatientList[];
const baseUrl = 'http://localhost:5024/api'

export async function registerPatient(patientFormData: IPatient): Promise<string> {
    const response = await fetch(`${baseUrl}/Auth/RegisterPatient`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(patientFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function updatePatient(id: string, patientFormData: IUpdatePatient): Promise<string> {
    const response = await fetch(`${baseUrl}/Patient/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(patientFormData)
      });
      const data = await response.json();
      return data.successMessage;
}


export async function getPatient(): Promise<IPatientList[]> {

  const data = await fetchApi(`${baseUrl}/Patient`,"GET");
  patients = data.value;
  return patients;
}

export async function getPatientById(id: string): Promise<IPatientList> {
  let patient: IPatientList;
  const response = await fetch(`${baseUrl}/Patient/${id}`, {
      method: "GET",
      headers: {
          'Content-Type': 'application/json',
          'Authorization': token
      },
  })
  const data = await response.json();
  patient = data.value;
  return patient;
}
export async function deletePatient(id: string) {
    const response = await fetch(`${baseUrl}/Patient?id=${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}