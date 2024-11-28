import { IMedicine } from "./Medicine";

export interface IPrescription {
    id: number,
    name: string,
    description: string,
    date: Date,
    patientName: string,
    doctorName: string,
    medicines: IMedicine[]
}