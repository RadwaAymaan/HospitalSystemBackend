export interface IPatient {
  patientEmail: string,
  patientFirstName: string,
  patientLastName: string,
  dateOfBirth:Date,
  userName: string,
  password: string,
  gender: string,
  patientPhoneNumber: string;
}

export interface IUpdatePatient {
  patientEmail: string,
  patientFirstName: string,
  patientLastName: string,
  dateOfBirth:Date,
  userName: string,
  gender: string,
  patientPhoneNumber: string;
}

export interface IPatientList extends IPatient {
  id:string
}
