import { IInsertTimeSlot, ITimeSlot } from "interfaces/ITimeSlot";
import token from "./token";

const BaseUrl="http://localhost:5024/api/TimeSlot";

export async function GetTimeSlot(): Promise<ITimeSlot[]> {
    let timeSlots: ITimeSlot[];
    const response = await fetch(BaseUrl, {
        method: "GET",
        headers:
         {
            'Content-Type': 'application/json',
            'Authorization': token,
         },
    })
    const data = await response.json();
    timeSlots = data.value;
    console.log(timeSlots);
    return timeSlots;
}
export async function GetTimeSlotById(id: number): Promise<ITimeSlot> {
    let timeSlot: ITimeSlot;
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
     timeSlot = data.value;
    console.log(timeSlot);
    return timeSlot;
}

export async function AddTimeSlot(TimeSlotFormData: IInsertTimeSlot): Promise<string> {
    console.log(TimeSlotFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(TimeSlotFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateTimeSlot(id: number, TimeSlotFormData: IInsertTimeSlot): Promise<string> {
    console.log(TimeSlotFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(TimeSlotFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteTimeSlot(id: number) {
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