import token from "./token";
import { IPrescription } from "interfaces/IPrescription";
import { InsertPrescription } from "interfaces/InsertPrescription";

const BaseUrl = "http://localhost:5024/api/Prescription";

export async function getPrescriptions(): Promise<IPrescription[]> {
    let prescriptions: IPrescription[];
    const response = await fetch(`${BaseUrl}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    prescriptions = data.value;
    console.log(prescriptions);
    return prescriptions;
}

export async function getPrescriptionById(id: string): Promise<IPrescription> {
    let prescription: IPrescription;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    prescription = data.value;
    console.log(prescription);
    return prescription;
}

export async function AddPrescription(prescriptionFormData: InsertPrescription): Promise<string> {
    console.log(prescriptionFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(prescriptionFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdatePrescription(id: string, prescriptionFormData: InsertPrescription): Promise<string> {
    console.log(prescriptionFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(prescriptionFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeletePrescription(id: number) {
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      console.log(data);
      return data.successMessage;
}