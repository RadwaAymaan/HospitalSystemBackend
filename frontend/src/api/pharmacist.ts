import { IInsertPharmacist, IPharmacist } from "interfaces/IPharmacist";
import token from "./token";

export async function getPharmacists(): Promise<IPharmacist[]> {
    let pharmacists: IPharmacist[];
    const response = await fetch("http://localhost:5024/api/Pharmacist", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    pharmacists = data.value;
    console.log(pharmacists);
    return pharmacists;
}

export async function getPharmacistById(id: string): Promise<IPharmacist> {
    let pharmacist: IPharmacist;
    const response = await fetch(`http://localhost:5024/api/Pharmacist/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    pharmacist = data.value;
    console.log(pharmacist);
    return pharmacist;
}

export async function AddPharmacist(pharmacistFormData: IInsertPharmacist): Promise<string> {
    console.log(pharmacistFormData);
    const response = await fetch('http://localhost:5024/api/Pharmacist', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(pharmacistFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdatePharmacist(id: string, pharmacistFormData: IPharmacist): Promise<string> {
    console.log(pharmacistFormData);
    const response = await fetch(`http://localhost:5024/api/Pharmacist/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(pharmacistFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeletePharmacist(id: number) {
    const response = await fetch(`http://localhost:5024/api/Pharmacist?id=${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}