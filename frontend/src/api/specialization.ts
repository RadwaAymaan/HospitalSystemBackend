
import { IInsertSpecialization, ISpecialization } from "interfaces/specialization";
import { token } from "./token";


export async function getSpecializations(): Promise<ISpecialization[]> {
    let specializations: ISpecialization[];
    const response = await fetch("http://localhost:5024/api/Specialization", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    specializations = data.value;
    console.log(specializations);
    return specializations;
}

export async function getSpecializationById(id: number): Promise<ISpecialization> {
    let specialization: ISpecialization;
    const response = await fetch(`http://localhost:5024/api/Specialization/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    specialization = data.value;
    console.log(specialization);
    return specialization;
}

export async function AddSpecialization(specializationFormData: IInsertSpecialization): Promise<string> {
    console.log(specializationFormData);
    const response = await fetch('http://localhost:5024/api/Specialization', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(specializationFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateSpecialization(id: number, specializationFormData: ISpecialization): Promise<string> {
    console.log(specializationFormData);
    const response = await fetch(`http://localhost:5024/api/Specialization/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(specializationFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteSpecialization(id: number) {
    const response = await fetch(`http://localhost:5024/api/Specialization?id=${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}