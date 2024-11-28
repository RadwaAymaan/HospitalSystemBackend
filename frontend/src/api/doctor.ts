import { IDoctor,IInsertDoctor } from "interfaces/IDoctor";
import token from "./token";

export async function getDoctors(): Promise<IDoctor[]> {
    let doctors: IDoctor[];
    const response = await fetch("http://localhost:5024/api/Doctor", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    doctors = data.value;
    console.log(doctors);
    return doctors;
}

export async function getDoctorById(id: string): Promise<IDoctor> {
    let doctor: IDoctor;
    const response = await fetch(`http://localhost:5024/api/Doctor/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    doctor = data.value;
    console.log(doctor);
    return doctor;
}

export async function AddDoctor(doctorFormData: IInsertDoctor): Promise<string> {
    console.log(doctorFormData);
    const response = await fetch('http://localhost:5024/api/Doctor', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(doctorFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateDoctor(id: string, doctorFormData: IDoctor): Promise<string> {
    console.log(doctorFormData);
    const response = await fetch(`http://localhost:5024/api/Doctor/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(doctorFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteDoctor(id: string) {
    const response = await fetch(`http://localhost:5024/api/Doctor?id=${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}