"use client";

import { ILabTest } from "interfaces/ILabTest";
import token from "./token";
import { IInsertLabTest } from "interfaces/IInsertLabTest";

const BaseUrl = "http://localhost:5024/api/MedicalTest/Lab";

export async function getLabTests(): Promise<ILabTest[]> {
    let labTests: ILabTest[];
    const response = await fetch(`${BaseUrl}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token,
            'Cache-Control': 'no-cache, no-store, must-revalidate'
        },
    })
    const data = await response.json();
    labTests = data.value;
    console.log(labTests);
    return labTests;
}

export async function getLabTestById(id: string): Promise<ILabTest> {
    let labTest: ILabTest;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token,
            'Cache-Control': 'no-cache, no-store, must-revalidate'
        },
    })
    const data = await response.json();
    labTest = data.value;
    console.log(labTest);
    return labTest;
}

export async function AddLabTest(labTestFormData: IInsertLabTest): Promise<string> {
    console.log(labTestFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(labTestFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateLabTest(id: string, labTestFormData: IInsertLabTest): Promise<string> {
    console.log(labTestFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(labTestFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteLabTest(id: number) {
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