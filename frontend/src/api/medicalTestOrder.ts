import token from "./token";
import { IMedicalTestOrder } from "interfaces/IMedicalTestOrder";
import { IInsertMedicalTestOrder } from "interfaces/IInsertMedicalTestOrder";

const BaseUrl = "http://localhost:5024/api/MedicalTestOrder";

export async function getMedicalTestOrders(): Promise<IMedicalTestOrder[]> {
    let medicalTestOrders: IMedicalTestOrder[];
    const response = await fetch(`${BaseUrl}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    medicalTestOrders = data.value;
    return medicalTestOrders;
}

export async function getMedicalTestOrderById(id: string): Promise<IMedicalTestOrder> {
    let category: IMedicalTestOrder;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    category = data.value;
    return category;
}

export async function AddMedicalTestOrder(itemFormData: IInsertMedicalTestOrder): Promise<string> {
    console.log(itemFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(itemFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateMedicalTestOrder(id: string, medicalTestOrderFormData: IInsertMedicalTestOrder): Promise<string> {
    console.log(medicalTestOrderFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(medicalTestOrderFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteMedicalTestOrder(id: number) {
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}

// export async function getLabTest() {
//   const response = await fetch("http://localhost:5024/api/MedicalTest/Lab", {
//       method: "GET",
//       headers: {
//           'Content-Type': 'application/json',
//           'Authorization': token
//       },
//   })
//   const data = await response.json();
//   console.log(data);
//   return data.value;
// }

export async function getPatient() {
    const response = await fetch("http://localhost:5024/api/Patient", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    console.log(data);
    return data.value;
  }