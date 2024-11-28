import { IPrescription } from "./IPrescription"

export interface IMedicineList {
    id : number
	medicineName: string,
    medicineDescription:string,
    medicineDosage:number
    prescriptions:IPrescription[]
	
}

export interface IMedicine{
	medicineName: string,
	medicineDescription: string,
    medicineDosage:number,
}