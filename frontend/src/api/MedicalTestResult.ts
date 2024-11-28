
import { IInsertMedicalTestResult, IMedicalTestResult } from "interfaces/IMedicalTestResult";
import token from "./token";

export async function getMedicalTestResults(): Promise<IMedicalTestResult[]> {
    let medicalTestResult: IMedicalTestResult[];
    const response = await fetch("http://localhost:5024/api/MedicalTestResult", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    medicalTestResult = data.value;
    console.log(medicalTestResult);
    return medicalTestResult;
}

export async function getMedicalTestResultById(id: number): Promise<IMedicalTestResult> {
    let medicalTestResult: IMedicalTestResult;
    const response = await fetch(`http://localhost:5024/api/MedicalTestResult/${id}`, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': token
        },
    })
    const data = await response.json();
    medicalTestResult = data.value;
    console.log(medicalTestResult);
    return medicalTestResult;
}

export async function addMedicalTestResult(medicalTestResultFormData: IInsertMedicalTestResult): Promise<string> {
    console.log(medicalTestResultFormData);
    const response = await fetch('http://localhost:5024/api/MedicalTestResult', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(medicalTestResultFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function UpdateMedicalTestResult(id: number, medicalTestResultFormData: IMedicalTestResult): Promise<string> {
    console.log(medicalTestResultFormData);
    const response = await fetch(`http://localhost:5024/api/MedicalTestResult/${id}`, {
        method: 'Put',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        },
        body: JSON.stringify(medicalTestResultFormData)
      });
      const data = await response.json();
      return data.successMessage;
}

export async function DeleteMedicalTestResult(id: number) {
    const response = await fetch(`http://localhost:5024/api/MedicalTestResult/${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': token,
        }
      });
      const data = await response.json();
      return data.successMessage;
}