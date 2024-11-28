import { IScanTest } from "interfaces/IScanTest";
import token from "./token";
import { IInsertScanTest } from "interfaces/IInsertScanTest";

const BaseUrl = "http://localhost:5024/api/MedicalTest/Scan";

export async function getScanTests(): Promise<IScanTest[]> {
    let scanTests: IScanTest[];
    const response = await fetch(`${BaseUrl}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    scanTests = data.value;
    console.log(scanTests);
    return scanTests;
}

export async function getScanTestById(id: string): Promise<IScanTest> {
    let scanTest: IScanTest;
    console.log(id);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    scanTest = data.value;
    console.log(scanTest);
    return scanTest;
}

export async function AddScanTest(scanTestFormData: IInsertScanTest): Promise<string> {
    console.log(scanTestFormData);
    const response = await fetch(`${BaseUrl}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(scanTestFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateScanTest(id: string, scanTestFormData: IInsertScanTest): Promise<string> {
    console.log(scanTestFormData);
    const response = await fetch(`${BaseUrl}/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(scanTestFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteScanTest(id: number) {
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