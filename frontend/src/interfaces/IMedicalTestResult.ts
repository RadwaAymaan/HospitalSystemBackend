export interface IMedicalTestResult {
	id: number;
	resultDescription: string;
	resultDate: Date;
	medicalTestOrder: {
		id: number;
		orderStatus: string;
		orderDate: Date;
		medicalTestName: string;
		patientName: string;
		doctorName: string;
		laboratoristName: string;
	},
	laboratoristName: string;
}
export interface IInsertMedicalTestResult {
	resultDescription:string;
	medicalTestOrderId: number;
	laboratoristId: string;
}