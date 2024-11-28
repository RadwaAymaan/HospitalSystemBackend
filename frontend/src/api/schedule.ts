import { ISchedule } from "interfaces/ISchedule";
import token from "./token";
import { IInsertSchedule } from "interfaces/IInsertSchedule";


const BaseUrl = "http://localhost:5024/api/Schedule";

export async function getSchedule(): Promise<ISchedule[]> {
    let schedules: ISchedule[];
    const response = await fetch(BaseUrl, {
        method: "GET",
        headers:
         {
            'Content-Type': 'application/json',
            'Authorization': token,
        },
    })
    const data = await response.json();
    schedules = data.value;
    console.log(schedules);
    return schedules;
}
export async function getScheduleById(id: number): Promise<ISchedule> {
    let Schedule: ISchedule;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers:
         {
            'Content-Type': 'application/json',
            'Authorization': token,
        },
    });
     const data = await response.json();
     Schedule = data.value;
    console.log(Schedule);
    return Schedule;
}

export async function AddSchedule(ScheduleFormData: IInsertSchedule): Promise<string> {
    console.log(ScheduleFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(ScheduleFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateSchedule(id: number, ScheduleFormData: IInsertSchedule): Promise<string> {
    console.log(ScheduleFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(ScheduleFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteSchedule(id: number) {
    const response = await fetch(`${BaseUrl}?id=${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}
