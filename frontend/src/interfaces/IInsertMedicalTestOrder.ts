enum Status {
  Pending,
  Approved,
  Cancelled
}
export interface IInsertMedicalTestOrder {
  orderStatus: Status;
  medicalTestId: number;
  patientId: string;
  doctorId: string;
  laboratoristId: string;
}
