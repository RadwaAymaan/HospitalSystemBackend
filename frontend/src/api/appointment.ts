 import { IAppointment, IInsertAppointment } from "interfaces/IAppointment";
import fetchApi from "./baseFetch";

const BaseUrl = "http://localhost:5024/api/Appointment";

export async function GetAppointment(): Promise<IAppointment[]> {
  const data = await fetchApi<IAppointment[]>(BaseUrl, "GET", {});
  console.log(data);
  return data;
}

export async function GetAppointmentById(id: string): Promise<IAppointment> {
  const data = await fetchApi<IAppointment>(`${BaseUrl}/${id}`, "GET", {});
  console.log(data);
  return data;
}

export async function AddAppointment(appointmentFormData: IInsertAppointment): Promise<string> {
  const data = await fetchApi<string>(BaseUrl, "POST", {}, appointmentFormData);
  console.log(data);
  return data;
}

export async function UpdateAppointment(id: string, appointmentFormData: IAppointment): Promise<string> {
  const data = await fetchApi<string>(`${BaseUrl}/${id}`, "PUT", {}, appointmentFormData);
  console.log(data);
  return data;
}

export async function DeleteAppointment(id: number): Promise<string> {
  
  const data = await fetchApi<string>(`${BaseUrl}?id=${id}`, "DELETE", {});
  console.log(data);
  return data;
}