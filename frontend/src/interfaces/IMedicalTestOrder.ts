enum Status {
  Pending,
  Approved,
  Cancelled,
}

export interface IMedicalTestOrder {
  id: number;
  orderStatus: Status;
  orderDate: Date;
  medicalTestName: string;
  patientName: string;
  doctorName: string;
  laboratoristName: string;
}
